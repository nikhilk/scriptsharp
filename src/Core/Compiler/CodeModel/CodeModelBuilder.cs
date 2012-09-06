// CodeModelBuilder.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using ScriptSharp;
using ScriptSharp.Parser;

namespace ScriptSharp.CodeModel {

    internal sealed class CodeModelBuilder {

        private CompilerOptions _options;
        private IErrorHandler _errorHandler;

        private bool _hasErrors;

        public CodeModelBuilder(CompilerOptions options, IErrorHandler errorHandler) {
            _options = options;
            _errorHandler = errorHandler;
        }

        public CompilationUnitNode BuildCodeModel(IStreamSource source) {
            _hasErrors = false;

            string filePath = source.FullName;
#if DEBUG
            if (_options.InternalTestMode) {
                // This ensures in file paths are just file names in test output.
                filePath = Path.GetFileName(filePath);
            }
#endif // DEBUG
            char[] buffer = GetBuffer(source);
            if (buffer == null) {
                _errorHandler.ReportError("Unable to read from file " + filePath, filePath);
                return null;
            }

            IDictionary definesTable = new Hashtable();
            if ((_options.Defines != null) && (_options.Defines.Count != 0)) {
                foreach (string s in _options.Defines) {
                    definesTable[s] = null;
                }
            }

            NameTable nameTable = new NameTable();
            LineMap lineMap = new LineMap(filePath);

            FileLexer lexer = new FileLexer(nameTable, filePath);
            lexer.OnError += new FileErrorEventHandler(OnError);
            Token[] tokens = lexer.Lex(buffer, definesTable, lineMap, /* includeComments */ false);

            if (_hasErrors == false) {
                FileParser parser = new FileParser(nameTable, filePath);
                parser.OnError += new FileErrorEventHandler(OnError);

                CompilationUnitNode compilationUnit = parser.Parse(tokens, lineMap);
                foreach (ParseNode node in compilationUnit.Members) {
                    NamespaceNode namespaceNode = node as NamespaceNode;
                    if (namespaceNode != null) {
                        namespaceNode.IncludeCompilationUnitUsingClauses();
                    }
                }

                if (_hasErrors == false) {
                    return compilationUnit;
                }
            }

            return null;
        }

        private char[] GetBuffer(IStreamSource source) {
            char[] buffer = null;

            Stream stream = source.GetStream();
            if (stream != null) {
                StreamReader reader = new StreamReader(stream);
                string text = reader.ReadToEnd();

                buffer = text.ToCharArray();
                source.CloseStream(stream);
            }
            return buffer;
        }

        private void OnError(object sender, FileErrorEventArgs e) {
            _hasErrors = true;

            string location = e.Position.ToString();
            string message = String.Format(e.Error.Message, e.Args);

            _errorHandler.ReportError(message, location);
        }
    }
}
