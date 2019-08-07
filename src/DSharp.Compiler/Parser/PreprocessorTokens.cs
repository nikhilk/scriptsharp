// PreprocessorTokens.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Diagnostics;

namespace DSharp.Compiler.Parser
{
    internal class PreprocessorToken
    {
        private static readonly string[] Strings =
        {
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
            "invalid"
        };

        public PreprocessorToken(PreprocessorTokenType type, BufferPosition position)
        {
            Type = type;
            Position = position;
        }

        public BufferPosition Position { get; }

        public PreprocessorTokenType Type { get; }

        public static string TypeString(PreprocessorTokenType type)
        {
            Debug.Assert(Strings.Length == (int) PreprocessorTokenType.Last);

            return Strings[(int) type];
        }
    }
}