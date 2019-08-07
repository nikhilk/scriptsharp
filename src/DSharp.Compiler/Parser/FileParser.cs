// FileParser.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Tokens;
using DSharp.Compiler.CodeModel.Types;

namespace DSharp.Compiler.Parser
{
    /// <summary>
    ///     Preprocesses, Lexes and Parses a C# Compilation Unit
    ///     Uses a FileLexer and a Parser object.
    /// </summary>
    internal sealed class FileParser
    {
        private readonly Parser parser;

        private LineMap lineMap;
        private NameTable nameTable;
        private string path;

        public FileParser(NameTable nameTable, string path)
        {
            this.nameTable = nameTable;
            this.path = path;
            parser = new Parser(nameTable, path);
            parser.OnError += OnParserError;
        }

        /// <summary>
        ///     Event to receive error notifications on. Subscribe to this event before calling Parse.
        /// </summary>
        public event FileErrorEventHandler OnError;

        private void OnParserError(object sender, ErrorEventArgs e)
        {
            if (OnError != null)
            {
                OnError(this, new FileLexerErrorEventArgs(e, lineMap));
            }
        }

        /// <summary>
        ///     Preprocesses, Lexes and Parses a C# compilation unit. Subscribe to the OnError
        ///     event before calling this method to receive error notifications.
        ///     After calling Parse, the Defines property contains the list of preprocessor
        ///     symbols defined as a result of #define and #undef directives in this
        ///     compilation unit.
        /// </summary>
        public CompilationUnitNode Parse(Token[] tokens, LineMap lineMap)
        {
            this.lineMap = lineMap;
            CompilationUnitNode parseTree = parser.Parse(tokens);
            this.lineMap = null;

            return parseTree;
        }
    }
}