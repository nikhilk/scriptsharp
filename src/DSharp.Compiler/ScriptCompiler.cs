using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using DSharp.Compiler.CodeModel;
using DSharp.Compiler.CodeModel.Types;
using DSharp.Compiler.Compiler;
using DSharp.Compiler.Errors;
using DSharp.Compiler.Generator;
using DSharp.Compiler.Importer;
using DSharp.Compiler.ScriptModel.Symbols;
using DSharp.Compiler.Validator;

namespace DSharp.Compiler
{
    public sealed class ScriptCompiler : IErrorHandler
    {
        private readonly IErrorHandler errorHandler;
        private ICollection<TypeSymbol> appSymbols;

        private ParseNodeList compilationUnitList;
        private bool hasErrors;
        private ICollection<TypeSymbol> importedSymbols;

        private CompilerOptions options;
        private SymbolSet symbols;

        public ScriptCompiler()
            : this(null)
        {
        }

        public ScriptCompiler(IErrorHandler errorHandler)
        {
            this.errorHandler = errorHandler;
        }

        void IErrorHandler.ReportError(CompilerError error)
        {
            hasErrors = true;
            if (errorHandler != null)
            {
                errorHandler.ReportError(error);
                return;
            }

            //TODO: Look at adding a logger interface
            LogError(error);
        }

        private void LogError(CompilerError error)
        {
            if (error.ColumnNumber != null || error.LineNumber != null)
            {
                Console.Error.WriteLine($"{error.File}({error.LineNumber.GetValueOrDefault()},{error.ColumnNumber.GetValueOrDefault()})");
            }

            Console.Error.WriteLine(error.Description);
        }

        private void BuildCodeModel()
        {
            compilationUnitList = new ParseNodeList();

            CodeModelBuilder codeModelBuilder = new CodeModelBuilder(options, this);
            CodeModelValidator codeModelValidator = new CodeModelValidator(this);
            CodeModelProcessor validationProcessor = new CodeModelProcessor(codeModelValidator, options);

            foreach (IStreamSource source in options.Sources)
            {
                CompilationUnitNode compilationUnit = codeModelBuilder.BuildCodeModel(source);

                if (compilationUnit != null)
                {
                    validationProcessor.Process(compilationUnit);

                    compilationUnitList.Append(compilationUnit);
                }
            }
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

        //TODO: Look at removing the internal testing type mechanism in favour of testing the compiler correctly.
        private void BuildMetadata()
        {
            if (options.Resources != null && options.Resources.Count != 0)
            {
                ResourcesBuilder resourcesBuilder = new ResourcesBuilder(symbols);
                resourcesBuilder.BuildResources(options.Resources);
            }

            MetadataBuilder mdBuilder = new MetadataBuilder(this);
            appSymbols = mdBuilder.BuildMetadata(compilationUnitList, symbols, options);

            // Check if any of the types defined in this assembly conflict.
            Dictionary<string, TypeSymbol> types = new Dictionary<string, TypeSymbol>();

            foreach (TypeSymbol appType in appSymbols)
            {
                if (appType.IsApplicationType == false || appType.Type == SymbolType.Delegate)
                {
                    // Skip the check for types that are marked as imported, as they
                    // aren't going to be generated into the script.
                    // Delegates are implicitly imported types, as they're never generated into
                    // the script.
                    continue;
                }

                if (appType.Type == SymbolType.Class &&
                    ((ClassSymbol)appType).PrimaryPartialClass != appType)
                {
                    // Skip the check for partial types, since they should only be
                    // checked once.
                    continue;
                }

                // TODO: We could allow conflicting types as long as both aren't public
                //       since they won't be on the exported types list. Internal types that
                //       conflict could be generated using full name.

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

            ISymbolTransformer transformer = null;

            if (options.Minimize)
            {
                transformer = new SymbolObfuscator();
            }
            else
            {
                transformer = new SymbolInternalizer();
            }

            if (transformer != null)
            {
                SymbolSetTransformer symbolSetTransformer = new SymbolSetTransformer(transformer);
                ICollection<Symbol> transformedSymbols =
                    symbolSetTransformer.TransformSymbolSet(symbols, /* useInheritanceOrder */ true);
            }
        }

        public bool Compile(CompilerOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            this.options = options;

            hasErrors = false;
            symbols = new SymbolSet();

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

            if (hasErrors)
            {
                return false;
            }

            return true;
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

        private void ImportMetadata()
        {
            MetadataImporter mdImporter = new MetadataImporter(this);

            importedSymbols = mdImporter.ImportMetadata(options.References, symbols);
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
    }
}
