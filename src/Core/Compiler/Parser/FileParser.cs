// FileParser.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.IO;
using System.Collections;
using System.Diagnostics;
using ScriptSharp.CodeModel;

namespace ScriptSharp.Parser {

    /// <summary>
    /// Preprocesses, Lexes and Parses a C# Compilation Unit
    /// Uses a FileLexer and a Parser object.
    /// </summary>
    internal sealed class FileParser {

        private LineMap _lineMap;
        private Parser _parser;
        private NameTable _nameTable;
        private string _path;

        public FileParser(NameTable nameTable, string path) {
            _nameTable = nameTable;
            _path = path;
            _parser = new Parser(nameTable, path);
            _parser.OnError += new ErrorEventHandler(OnParserError);
        }

        /// <summary>
        /// Event to receive error notifications on. Subscribe to this event before calling Parse.
        /// </summary>
        public event FileErrorEventHandler OnError;

        private void OnParserError(object sender, ErrorEventArgs e) {
            if (OnError != null) {
                OnError(this, new FileErrorEventArgs(e, _lineMap));
            }
        }

        /// <summary>
        /// Preprocesses, Lexes and Parses a C# compilation unit. Subscribe to the OnError
        /// event before calling this method to receive error notifications.
        /// After calling Parse, the Defines property contains the list of preprocessor
        /// symbols defined as a result of #define and #undef directives in this
        /// compilation unit.
        /// </summary>
        public CompilationUnitNode Parse(Token[] tokens, LineMap lineMap) {
            _lineMap = lineMap;
            CompilationUnitNode parseTree = _parser.Parse(tokens);
            _lineMap = null;

            return parseTree;
        }
    }
}
