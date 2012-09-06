// PreprocessorTokens.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.Parser {

    internal class PreprocessorToken {

        private static readonly string[] strings = new string[] {
            "define",
            "undef",
            "if",
            "elif",
            "else",
            "endif",
            "error",
            "warning",
            "line",
            "default",
            "hidden",
            "true",
            "false",
            "region",
            "endregion",
            "pragma",

            "identifier",

            "integer constant",
            "string constant",
            "!",
            "==",
            "!=",
            "&&",
            "||",
            "(",
            ")",
            "end of line",
            "unknown",
            "invalid",
        };

        private PreprocessorTokenType _type;
        private BufferPosition _position;

        public PreprocessorToken(PreprocessorTokenType type, BufferPosition position) {
            _type = type;
            _position = position;
        }

        public BufferPosition Position {
            get {
                return _position;
            }
        }

        public PreprocessorTokenType Type {
            get {
                return _type;
            }
        }

        public static string TypeString(PreprocessorTokenType type) {
            Debug.Assert(strings.Length == (int)PreprocessorTokenType.Last);
            return strings[(int)type];
        }
    }
}
