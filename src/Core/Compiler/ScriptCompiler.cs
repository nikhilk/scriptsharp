// ScriptCompiler.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using ScriptSharp.CodeModel;
using ScriptSharp.Compiler;
using ScriptSharp.Generator;
using ScriptSharp.Importer;
using ScriptSharp.ResourceModel;
using ScriptSharp.ScriptModel;
using ScriptSharp.Validator;

namespace ScriptSharp {

    /// <summary>
    /// The Script# compiler.
    /// </summary>
    public sealed class ScriptCompiler : IErrorHandler, IStreamResolver, IScriptInfo {

        private CompilerOptions _options;
        private IErrorHandler _errorHandler;

        private ParseNodeList _compilationUnitList;
        private SymbolSet _symbols;
        private ICollection<TypeSymbol> _importedSymbols;
        private ICollection<TypeSymbol> _appSymbols;
        private bool _hasErrors;

#if DEBUG
        private string _testOutput;
#endif

        public ScriptCompiler()
            : this(null) {
        }

        public ScriptCompiler(IErrorHandler errorHandler) {
            _errorHandler = errorHandler;
        }

        private void BuildCodeModel() {
            _compilationUnitList = new ParseNodeList();

            CodeModelBuilder codeModelBuilder = new CodeModelBuilder(_options, this);
            CodeModelValidator codeModelValidator = new CodeModelValidator(this);
            CodeModelProcessor validationProcessor = new CodeModelProcessor(codeModelValidator, _options);

            foreach (IStreamSource source in _options.Sources) {
                CompilationUnitNode compilationUnit = codeModelBuilder.BuildCodeModel(source);
                if (compilationUnit != null) {
                    validationProcessor.Process(compilationUnit);

                    _compilationUnitList.Append(compilationUnit);
                }
            }
        }

        private void BuildImplementation() {
            CodeBuilder codeBuilder = new CodeBuilder(_options, this);
            ICollection<SymbolImplementation> implementations = codeBuilder.BuildCode(_symbols);

            if (_options.Minimize) {
                foreach (SymbolImplementation impl in implementations) {
                    if (impl.Scope == null) {
                        continue;
                    }

                    SymbolObfuscator obfuscator = new SymbolObfuscator();
                    SymbolImplementationTransformer transformer = new SymbolImplementationTransformer(obfuscator);

                    transformer.TransformSymbolImplementation(impl);
                }
            }
        }

        private void BuildMetadata() {
            if ((_options.Resources != null) && (_options.Resources.Count != 0)) {
                ResourcesBuilder resourcesBuilder = new ResourcesBuilder(_symbols);
                resourcesBuilder.BuildResources(_options.Resources);
            }

            MetadataBuilder mdBuilder = new MetadataBuilder(this);
            _appSymbols = mdBuilder.BuildMetadata(_compilationUnitList, _symbols, _options);

            // Check if any of the types defined in this assembly conflict against types in
            // imported assemblies.

            Dictionary<string, TypeSymbol> types = new Dictionary<string, TypeSymbol>();
            foreach (TypeSymbol importedType in _importedSymbols) {
                types[importedType.FullGeneratedName] = importedType;
            }

            foreach (TypeSymbol appType in _appSymbols) {
                if ((appType.IsApplicationType == false) || (appType.Type == SymbolType.Delegate)) {
                    // Skip the check for types that are marked as imported, as they
                    // aren't going to be generated into the script.
                    // Delegates are implicitly imported types, as they're never generated into
                    // the script.
                    continue;
                }

                if ((appType.Type == SymbolType.Class) &&
                    (((ClassSymbol)appType).PrimaryPartialClass != appType)) {
                    // Skip the check for partial types, since they should only be
                    // checked once.
                    continue;
                }

                string name = appType.FullGeneratedName;
                if (types.ContainsKey(name)) {
                    string error = "The type '" + name + "' conflicts with another existing type with the same full name. This might be because a referenced assembly uses the same type, or you have multiple types with the same name across namespaces mapped to the same script namespace.";
                    ((IErrorHandler)this).ReportError(error, null);
                }
                else {
                    types[name] = appType;
                }
            }

            // Capture whether there are any test types in the project
            // when not compiling the test flavor script. This is used to determine
            // if the test flavor script should be compiled in the build task.

            if (_options.IncludeTests == false) {
                foreach (TypeSymbol appType in _appSymbols) {
                    if (appType.IsApplicationType && appType.IsTestType) {
                        _options.HasTestTypes = true;
                    }
                }
            }

#if DEBUG
            if (_options.InternalTestType == "metadata") {
                StringWriter testWriter = new StringWriter();

                testWriter.WriteLine("Metadata");
                testWriter.WriteLine("================================================================");

                SymbolSetDumper symbolDumper = new SymbolSetDumper(testWriter);
                symbolDumper.DumpSymbols(_symbols);

                testWriter.WriteLine();
                testWriter.WriteLine();

                _testOutput = testWriter.ToString();
            }
#endif // DEBUG

            if (_options.Minimize) {
                SymbolObfuscator obfuscator = new SymbolObfuscator();
                SymbolSetTransformer obfuscationTransformer = new SymbolSetTransformer(obfuscator);

                ICollection<Symbol> obfuscatedSymbols = obfuscationTransformer.TransformSymbolSet(_symbols, /* useInheritanceOrder */ true);

#if DEBUG
                if (_options.InternalTestType == "minimizationMap") {
                    StringWriter testWriter = new StringWriter();

                    testWriter.WriteLine("Minimization Map");
                    testWriter.WriteLine("================================================================");

                    List<Symbol> sortedObfuscatedSymbols = new List<Symbol>(obfuscatedSymbols);
                    sortedObfuscatedSymbols.Sort(delegate(Symbol s1, Symbol s2) {
                        return String.Compare(s1.Name, s2.Name);
                    });

                    foreach (Symbol obfuscatedSymbol in sortedObfuscatedSymbols) {
                        if (obfuscatedSymbol is TypeSymbol) {
                            TypeSymbol typeSymbol = (TypeSymbol)obfuscatedSymbol;

                            testWriter.WriteLine("Type '" + typeSymbol.FullName + "' renamed to '" + typeSymbol.GeneratedName + "'");
                        }
                        else {
                            Debug.Assert(obfuscatedSymbol is MemberSymbol);
                            testWriter.WriteLine("    Member '" + obfuscatedSymbol.Name + "' renamed to '" + obfuscatedSymbol.GeneratedName + "'");
                        }
                    }

                    testWriter.WriteLine();
                    testWriter.WriteLine();

                    _testOutput = testWriter.ToString();
                }
#endif // DEBUG
            }
            else {
                if (_options.DebugFlavor) {
                    SymbolInternalizer internalizer = new SymbolInternalizer();
                    SymbolSetTransformer internalizingTransformer = new SymbolSetTransformer(internalizer);

                    internalizingTransformer.TransformSymbolSet(_symbols, /* useInheritanceOrder */ true);
                }
            }
        }

        public bool Compile(CompilerOptions options) {
            if (options == null) {
                throw new ArgumentNullException("options");
            }
            _options = options;

            _hasErrors = false;
            _symbols = new SymbolSet();

            ImportMetadata();
            if (_hasErrors) {
                return false;
            }

            BuildCodeModel();
            if (_hasErrors) {
                return false;
            }

            BuildMetadata();
            if (_hasErrors) {
                return false;
            }

            BuildImplementation();
            if (_hasErrors) {
                return false;
            }

            GenerateScript();
            if (_hasErrors) {
                return false;
            }

            return true;
        }

        private void GenerateScript() {
            if (_options.TemplateFile != null) {
                PreprocessorOptions preprocessorOptions = new PreprocessorOptions();
                preprocessorOptions.SourceFile = _options.TemplateFile;
                preprocessorOptions.TargetFile = _options.ScriptFile;
                preprocessorOptions.DebugFlavor = _options.DebugFlavor;
                preprocessorOptions.Minimize = _options.Minimize;
                // preprocessorOptions.StripCommentsOnly = _options.StripCommentsOnly;
                preprocessorOptions.UseWindowsLineBreaks = !_options.Minimize;
                preprocessorOptions.PreprocessorVariables = _options.Defines;

                ScriptPreprocessor preprocessor = new ScriptPreprocessor(this, this, this);
                preprocessor.Preprocess(preprocessorOptions);
            }
            else {
                Stream outputStream = null;
                TextWriter outputWriter = null;

                try {
                    outputStream = _options.ScriptFile.GetStream();
                    if (outputStream == null) {
                        ((IErrorHandler)this).ReportError("Unable to write to file " + _options.ScriptFile.FullName,
                                                                  _options.ScriptFile.FullName);
                        return;
                    }

                    outputWriter = new StreamWriter(outputStream);

#if DEBUG
                    if (_options.InternalTestMode) {
                        if (_testOutput != null) {
                            outputWriter.Write(_testOutput);
                            outputWriter.WriteLine("Script");
                            outputWriter.WriteLine("================================================================");
                            outputWriter.WriteLine();
                            outputWriter.WriteLine();
                        }
                    }
#endif // DEBUG

                    GenerateScriptCore(outputWriter);
                }
                catch (Exception e) {
                    Debug.Fail(e.ToString());
                }
                finally {
                    if (outputWriter != null) {
                        outputWriter.Flush();
                    }
                    if (outputStream != null) {
                        _options.ScriptFile.CloseStream(outputStream);
                    }
                }
            }
        }

        private void GenerateScriptCore(TextWriter writer) {
            ScriptGenerator scriptGenerator = new ScriptGenerator(writer, _options, this);
            scriptGenerator.GenerateScript(_symbols);
        }

        private void ImportMetadata() {
            MetadataImporter mdImporter = new MetadataImporter(_options, this);

            _importedSymbols = mdImporter.ImportMetadata(_options.References, _symbols);
        }

        #region Implementation of IErrorHandler
        void IErrorHandler.ReportError(string errorMessage, string location) {
            _hasErrors = true;

            if (_errorHandler != null) {
                _errorHandler.ReportError(errorMessage, location);
                return;
            }

            if (String.IsNullOrEmpty(location) == false) {
                Console.Error.Write(location);
                Console.Error.Write(": ");
            }

            Console.Error.WriteLine(errorMessage);
        }
        #endregion

        #region Implementation of IStreamResolver
        IStreamSource IStreamResolver.ResolveInclude(IStreamSource baseStream, string includePath) {
            if (includePath == "%code%") {
                StringBuilder sb = new StringBuilder(4096);
                StringWriter sw = new StringWriter(sb);

                sw.WriteLine();
                GenerateScriptCore(sw);

                string compiledCode = sb.ToString();
                return new CodeStreamSource(compiledCode);
            }
            else {
                IStreamResolver resolver = baseStream as IStreamResolver;
                if (resolver != null) {
                    return resolver.ResolveInclude(baseStream, includePath);
                }

                string resolvedPath = Path.Combine(Path.GetDirectoryName(Path.GetFullPath(baseStream.FullName)), includePath);
                return new FileInputStreamSource(resolvedPath);
            }
        }
        #endregion

        #region Implementation of IScriptInfo
        string IScriptInfo.GetValue(string name) {
            if (_symbols == null) {
                return null;
            }

            if (String.CompareOrdinal(name, "Name") == 0) {
                if (String.IsNullOrEmpty(_options.ScriptNameSuffix) == false) {
                    return _symbols.ScriptName + "." + _options.ScriptNameSuffix;
                }
                return _symbols.ScriptName;
            }
            if (String.CompareOrdinal(name, "ExecutionDependencies") == 0) {
                if (_options.ExecutionDependencies == null) {
                    return String.Empty;
                }

                bool first = true;
                StringBuilder sb = new StringBuilder();
                foreach (string scriptName in _options.ExecutionDependencies) {
                    if (first == false) {
                        sb.Append(",");
                    }
                    sb.Append(scriptName);
                    first = false;
                }

                return sb.ToString();
            }
            if (String.CompareOrdinal(name, "ScriptFile") == 0) {
                return Path.GetFileName(_options.ScriptFile.Name);
            }
            if (String.CompareOrdinal(name, "CompilerVersion") == 0) {
                string exePath = typeof(ScriptCompiler).Assembly.GetModules()[0].FullyQualifiedName;
                FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(exePath);

                return versionInfo.FileVersion;
            }

            return null;
        }
        #endregion


        private sealed class CodeStreamSource : IStreamSource {

            private string _code;

            public CodeStreamSource(string code) {
                _code = code;
            }

            public string FullName {
                get {
                    return "%code%";
                }
            }

            public string Name {
                get {
                    return "%code%";
                }
            }

            public void CloseStream(Stream stream) {
                Debug.Assert(stream != null);
                stream.Close();
            }

            public Stream GetStream() {
                byte[] buffer = Encoding.Default.GetBytes(_code);
                return new MemoryStream(buffer);
            }
        }
    }
}
