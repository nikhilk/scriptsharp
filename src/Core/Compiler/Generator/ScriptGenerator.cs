// ScriptGenerator.cs
// Script#/Core/ScriptSharp
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using ScriptSharp;
using ScriptSharp.ScriptModel;

namespace ScriptSharp.Generator {

    internal sealed class ScriptGenerator {

        private ScriptTextWriter _writer;
        private CompilerOptions _options;
        private IErrorHandler _errorHandler;

        private List<ClassSymbol> _classes;

        public ScriptGenerator(TextWriter writer, CompilerOptions options, IErrorHandler errorHandler) {
            Debug.Assert(writer != null);
            _writer = new ScriptTextWriter(writer, options);

            _options = options;
            _errorHandler = errorHandler;

            _classes = new List<ClassSymbol>();
        }

        public IErrorHandler ErrorHandler {
            get {
                return _errorHandler;
            }
        }

        public CompilerOptions Options {
            get {
                return _options;
            }
        }

        public ScriptTextWriter Writer {
            get {
                return _writer;
            }
        }

        public void AddGeneratedClass(ClassSymbol classSymbol) {
            Debug.Assert(classSymbol != null);
            _classes.Add(classSymbol);
        }

        private void GenerateClassRegistration(ClassSymbol classSymbol, List<ClassSymbol> generatedClasses) {
            Debug.Assert(classSymbol != null);

            if (generatedClasses.Contains(classSymbol)) {
                return;
            }

            ClassSymbol baseClass = classSymbol.BaseClass;
            if ((baseClass != null) && baseClass.IsApplicationType) {
                GenerateClassRegistration(baseClass, generatedClasses);
            }

            TypeGenerator.GenerateClassRegistrationScript(this, classSymbol);
            generatedClasses.Add(classSymbol);
        }

        public void GenerateScript(SymbolSet symbolSet) {
            Debug.Assert(symbolSet != null);

            Dictionary<string, bool> generatedNamespaces = new Dictionary<string, bool>();
            foreach (NamespaceSymbol namespaceSymbol in symbolSet.Namespaces) {
                if (namespaceSymbol.HasApplicationTypes) {
                    NamespaceGenerator.GenerateScript(this, namespaceSymbol, generatedNamespaces);
                }
            }

            List<ClassSymbol> generatedClasses = new List<ClassSymbol>(_classes.Count);
            foreach (ClassSymbol generatedClass in _classes) {
                if (generatedClass.HasGlobalMethods == false) {
                    GenerateClassRegistration(generatedClass, generatedClasses);
                }
            }

            // TODO: Couple of line-breaks would be nice here
            //       but only if there are any classes with static
            //       ctors or members

            foreach (ClassSymbol generatedClass in _classes) {
                TypeGenerator.GenerateClassConstructorScript(this, generatedClass);
            }

            if (Options.IncludeTests) {
                foreach (ClassSymbol generatedClass in _classes) {
                    if (generatedClass.IsTestClass) {
                        TestGenerator.GenerateScript(this, generatedClass);
                    }
                }
            }
        }
    }
}
