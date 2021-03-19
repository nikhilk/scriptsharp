using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using DSharp.Compiler.CodeModel;
using DSharp.Compiler.CodeModel.Types;
using DSharp.Compiler.Compiler;
using DSharp.Compiler.Errors;
using DSharp.Compiler.Generator;
using DSharp.Compiler.Importer;
using DSharp.Compiler.Preprocessing;
using DSharp.Compiler.Preprocessing.Lowering;
using DSharp.Compiler.References;
using DSharp.Compiler.ScriptModel.Symbols;
using DSharp.Compiler.Validator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;

namespace DSharp.Compiler
{
    public sealed class ScriptCompiler : IErrorHandler
    {
        private readonly IErrorHandler errorHandler;
        private ICollection<TypeSymbol> appSymbols;
        private HashSet<CompilationUnitNode> compilationUnitList = new HashSet<CompilationUnitNode>();
        private bool hasErrors;
        private CompilerOptions options;
        private SymbolSet symbols;
        private CSharpCompilation compilation;

        public ScriptCompiler()
            : this(null)
        {
        }

        public ScriptCompiler(IErrorHandler errorHandler)
        {
            this.errorHandler = errorHandler;
        }

        public bool Compile(CompilerOptions options)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));

            if (options.DebugMode)
            {
                Debugger.Launch();
            }

            hasErrors = false;
            symbols = new SymbolSet();
            ScriptReferenceProvider.Instance.Reset();

            ImportMetadata();

            if (hasErrors)
            {
                return false;
            }

            BuildCodeModel();

            if (hasErrors)
            {
                return false;
            }

            BuildMetadata();

            if (hasErrors)
            {
                return false;
            }

            BuildImplementation();

            if (hasErrors)
            {
                return false;
            }

            GenerateScript();

            GenerateMetadata();

            if (hasErrors)
            {
                return false;
            }

            return true;
        }

        private void GenerateMetadata()
        {
            Stream outputStream = null;
            TextWriter outputWriter = null;

            try
            {
                outputStream = options.MetadataFile?.GetStream();

                if (outputStream == null)
                {
                    return;
                }

                outputWriter = new StreamWriter(outputStream, new UTF8Encoding(false));
                ScriptMetadataGenerator scriptGenerator = new ScriptMetadataGenerator(outputWriter, options, symbols);
                scriptGenerator.GenerateScriptMetadata(symbols);
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                outputWriter?.Flush();

                if (outputStream != null)
                {
                    options.MetadataFile.CloseStream(outputStream);
                }
            }
        }

        private void ImportMetadata()
        {
            MetadataImporter mdImporter = new MetadataImporter(this);
            mdImporter.ImportMetadata(options.AssemblyName, options.References, symbols);
        }

        private void BuildCodeModel()
        {
            CodeModelBuilder codeModelBuilder = new CodeModelBuilder(options, this);
            CodeModelValidator codeModelValidator = new CodeModelValidator(this);
            CodeModelProcessor validationProcessor = new CodeModelProcessor(codeModelValidator, options);

            compilation = GetPreprocessedCompilation();
            IEnumerable<IStreamSource> sources = options.Sources.Select(s => GetPreprocessedSource(compilation, s));

            foreach (IStreamSource source in sources)
            {
                CompilationUnitNode compilationUnit = codeModelBuilder.BuildCodeModel(source);

                if (compilationUnit != null)
                {
                    validationProcessor.Process(compilationUnit);

                    compilationUnitList.Add(compilationUnit);
                }
            }
        }

        private CSharpCompilation GetPreprocessedCompilation()
        {
            CSharpParseOptions parseOptions = new CSharpParseOptions(preprocessorSymbols: options.Defines);
            var trees = options.Sources.Select(s => CSharpSyntaxTree.ParseText(path: s.FullName, text: SourceText.From(s.GetStream()), options: parseOptions));
            var references = options.References.Select(r => MetadataReference.CreateFromFile(r));
            var compilation = CSharpCompilation.Create(options.AssemblyName, trees, references);

            var lowerers = new ILowerer[] {
                new AnnotatedCSharpRewriter(),
                new StaticUsingRewriter(),
                new VarRewriter(this),
                new NamedArgumentsRewriter(this),
                new ExtensionMethodToStaticRewriter(),
                new LambdaRewriter(this),
                new EnumValueRewriter(),
                new GenericArgumentRewriter(), // avoids ambiguous overloads for the rest of the lowerers
                new ObjectInitializerRewriter(this),
                new ImplicitArrayCreationRewriter(),
                new OperatorOverloadRewriter(),
                new OptionalArgumentsRewriter(this),
                new GenericArgumentRewriter(), // ensures that generic calls always have explicit type params
                new FullyQualifiedTypeNameRewriter(),
            };

            compilation = CompilationPreprocessor.Preprocess(compilation, lowerers);

            IntermediarySourceManager intermediarySourceManager = new IntermediarySourceManager(options.IntermediarySourceFolder, errorHandler);
            intermediarySourceManager?.Write(compilation);

            return compilation;
        }

        private IStreamSource GetPreprocessedSource(CSharpCompilation comp, IStreamSource source)
        {
            return new SyntaxTreeSource(source.Name, comp.SyntaxTrees.Single(s => s.FilePath == source.FullName));
        }

        private void BuildMetadata()
        {
            if (options.Resources != null && options.Resources.Count != 0)
            {
                ResourcesBuilder resourcesBuilder = new ResourcesBuilder(symbols);
                resourcesBuilder.BuildResources(options.Resources);
            }

            MetadataBuilder mdBuilder = new MetadataBuilder(this);
            appSymbols = mdBuilder.BuildMetadata(compilationUnitList, symbols, options);

            CheckForDuplicateTypes();
            TransformSymbols();
        }

        private bool IsEmittableTypeSymbol(TypeSymbol typeSymbol)
        {
            //if (appType.IsApplicationType == false || appType.Type == SymbolType.Delegate)
            //{
            //    // Skip the check for types that are marked as imported, as they
            //    // aren't going to be generated into the script.
            //    // Delegates are implicitly imported types, as they're never generated into
            //    // the script.
            //    continue;
            //}

            var classSymbol = typeSymbol as ClassSymbol;
            if (classSymbol != null && classSymbol.PrimaryPartialClass != typeSymbol)
            {
                // Skip the check for partial types, since they should only be
                // checked once.
                return false;
            }

            return typeSymbol.IsApplicationType
                && typeSymbol.Type != SymbolType.Delegate
                || (classSymbol != null && classSymbol.PrimaryPartialClass != typeSymbol);
        }

        private void CheckForDuplicateTypes()
        {
            Dictionary<string, TypeSymbol> types = new Dictionary<string, TypeSymbol>();

            foreach (TypeSymbol appType in appSymbols.Where(symbol => IsEmittableTypeSymbol(symbol)))
            {
                string name = appType.GeneratedName;

                if (types.ContainsKey(name))
                {
                    ((IErrorHandler)this).ReportGeneralError(string.Format(DSharpStringResources.CONFLICTING_TYPE_NAME_ERROR_FORMAT, appType.FullName, types[name].FullName));
                }
                else
                {
                    types[name] = appType;
                }
            }
        }

        private void TransformSymbols()
        {
            ISymbolTransformer transformer;

            if (options.Minimize)
            {
                transformer = new SymbolObfuscator();
            }
            else
            {
                transformer = new SymbolInternalizer();
            }

            SymbolSetTransformer symbolSetTransformer = new SymbolSetTransformer(transformer);
            symbolSetTransformer.TransformSymbolSet(symbols, useInheritanceOrder: true);
        }

        private void BuildImplementation()
        {
            CodeBuilder codeBuilder = new CodeBuilder(options, this);
            ICollection<SymbolImplementation> implementations = codeBuilder.BuildCode(symbols);

            if (options.Minimize)
            {
                foreach (SymbolImplementation impl in implementations)
                {
                    if (impl.Scope == null)
                    {
                        continue;
                    }

                    SymbolObfuscator obfuscator = new SymbolObfuscator();
                    SymbolImplementationTransformer transformer = new SymbolImplementationTransformer(obfuscator);

                    transformer.TransformSymbolImplementation(impl);
                }
            }
        }

        private void GenerateScript()
        {
            Stream outputStream = null;
            TextWriter outputWriter = null;

            try
            {
                outputStream = options.ScriptFile.GetStream();

                if (outputStream == null)
                {
                    string scriptName = options.ScriptFile.FullName;
                    ((IErrorHandler)this).ReportMissingStreamError(scriptName);

                    return;
                }

                outputWriter = new StreamWriter(outputStream, new UTF8Encoding(false));

                string script = GenerateScriptWithTemplate();
                outputWriter.Write(script);
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                if (outputWriter != null)
                {
                    outputWriter.Flush();
                }

                if (outputStream != null)
                {
                    options.ScriptFile.CloseStream(outputStream);
                }
            }
        }

        private string GenerateScriptCore()
        {
            StringWriter scriptWriter = new StringWriter();

            try
            {
                ScriptGenerator scriptGenerator = new ScriptGenerator(scriptWriter, options, symbols);
                scriptGenerator.GenerateScript(symbols);
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                scriptWriter.Flush();
            }

            return scriptWriter.ToString();
        }

        private string GenerateScriptWithTemplate()
        {
            string script = GenerateScriptCore();

            string template = options.ScriptInfo.Template;

            if (string.IsNullOrEmpty(template))
            {
                return script;
            }

            template = PreprocessTemplate(template);

            StringBuilder requiresBuilder = new StringBuilder();
            StringBuilder dependenciesBuilder = new StringBuilder();
            StringBuilder depLookupBuilder = new StringBuilder();

            bool firstDependency = true;

            foreach (ScriptReference dependency in symbols.Dependencies)
            {
                if (dependency.DelayLoaded)
                {
                    continue;
                }

                if (dependency.TypeReferenceCount <= 0
                    && dependency.Identifier != DSharpStringResources.DSHARP_SCRIPT_NAME)
                {
                    if (dependency.ConstReferenceCount <= 0)
                    {
                        Console.WriteLine($"WARN: Unnecessary dependency to '{dependency.Identifier}'.");
                    }

                    continue;
                }

                if (firstDependency)
                {
                    depLookupBuilder.Append("var ");
                }
                else
                {
                    requiresBuilder.Append(", ");
                    dependenciesBuilder.Append(", ");
                    depLookupBuilder.Append(",\r\n    ");
                }

                string name = dependency.Name;

                if (name == DSharpStringResources.DSHARP_SCRIPT_NAME)
                {
                    // TODO: This is a hack... to make generated node.js scripts
                    //       be able to reference the 'dsharp' node module.
                    //       Fix this in a better/1st class manner by allowing
                    //       script assemblies to declare such things.
                    name = DSharpStringResources.DSHARP_SCRIPT_NAME;
                }

                requiresBuilder.Append("'" + dependency.Path + "'");
                dependenciesBuilder.Append(dependency.Identifier);

                depLookupBuilder.Append(dependency.Identifier);
                depLookupBuilder.Append(" = require('" + name + "')");

                firstDependency = false;
            }

            depLookupBuilder.Append(";");

            return template.TrimStart()
                           .Replace("{name}", symbols.ScriptName)
                           .Replace("{description}", options.ScriptInfo.Description ?? string.Empty)
                           .Replace("{copyright}", options.ScriptInfo.Copyright ?? string.Empty)
                           .Replace("{version}", options.ScriptInfo.Version ?? string.Empty)
                           .Replace("{compiler}", typeof(ScriptCompiler).Assembly.GetName().Version.ToString())
                           .Replace("{description}", options.ScriptInfo.Description)
                           .Replace("{requires}", requiresBuilder.ToString())
                           .Replace("{dependencies}", dependenciesBuilder.ToString())
                           .Replace("{dependenciesLookup}", depLookupBuilder.ToString())
                           .Replace("{script}", script);
        }

        private string PreprocessTemplate(string template)
        {
            if (options.IncludeResolver == null)
            {
                return template;
            }

            Regex includePattern = new Regex("\\{include:([^\\}]+)\\}",
                RegexOptions.Multiline | RegexOptions.CultureInvariant);

            return includePattern.Replace(template, delegate (Match include)
            {
                string includedScript = string.Empty;

                if (include.Groups.Count == 2)
                {
                    string includePath = include.Groups[1].Value;

                    IStreamSource includeSource = options.IncludeResolver.Resolve(includePath);

                    if (includeSource != null)
                    {
                        Stream includeStream = includeSource.GetStream();
                        StreamReader reader = new StreamReader(includeStream);

                        includedScript = reader.ReadToEnd();
                        includeSource.CloseStream(includeStream);
                    }
                }

                return includedScript;
            });
        }

        void IErrorHandler.ReportError(CompilerError error)
        {
            hasErrors = true;
            if (errorHandler != null)
            {
                errorHandler.ReportError(MapErrorLocation(error, compilation));
                return;
            }

            //TODO: Look at adding a logger interface
            WriteError(MapErrorLocation(error, compilation));
        }

        void IErrorHandler.ReportWarning(CompilerError error)
        {
            if (errorHandler != null)
            {
                errorHandler.ReportWarning(MapErrorLocation(error, compilation));
                return;
            }

            //TODO: Look at adding a logger interface
            WriteError(MapErrorLocation(error, compilation));
        }

        private void WriteError(CompilerError error)
        {
            if (error.ColumnNumber != null || error.LineNumber != null)
            {
                Console.Error.WriteLine($"{error.File}({error.LineNumber.GetValueOrDefault()}, {error.ColumnNumber.GetValueOrDefault()})");
            }

            Console.Error.WriteLine(error.Description);
        }

        private static CompilerError MapErrorLocation(CompilerError compilerError, Compilation compilation)
        {
            try
            {
                if (!compilerError.LineNumber.HasValue || !compilerError.ColumnNumber.HasValue || string.IsNullOrEmpty(compilerError.File))
                {
                    return compilerError;
                }

                var syntaxTree = compilation.SyntaxTrees.Where(s => s.FilePath == compilerError.File).SingleOrDefault();
                var pos = syntaxTree.GetText().Lines[compilerError.LineNumber.Value - 1].Start + compilerError.ColumnNumber.Value - 1;
                var node = syntaxTree.GetRoot().FindNode(new TextSpan(pos, 0));

                return new CompilerError(
                    errorCode: compilerError.ErrorCode,
                    description: compilerError.Description,
                    file: compilerError.File,
                    lineNumber: ParseAnnotation(node, "OriginalLineStart", p => p.StartLinePosition.Line) + 1,
                    columnNumber: ParseAnnotation(node, "OriginalColumnStart", p => p.StartLinePosition.Character) + 1
                );
            }
            catch
            {
                return compilerError;
            }

            int ParseAnnotation(SyntaxNode node, string name, Func<FileLinePositionSpan, int> getDefault)
            {
                if (node.GetAnnotations(name).FirstOrDefault() is SyntaxAnnotation annotation && annotation != default)
                {
                    return int.Parse(annotation.Data);
                }

                return getDefault.Invoke(node.GetLocation().GetLineSpan());
            }
        }
    }
}
