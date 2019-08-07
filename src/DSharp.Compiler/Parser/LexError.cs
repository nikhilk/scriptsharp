// LexError.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

namespace DSharp.Compiler.Parser
{
    internal sealed class LexError
    {
        public static readonly Error SyntaxError = new Error(101, 0, "Syntax Error");
        public static readonly Error UnexpectedCharacter = new Error(102, 0, "Unexected character '{0}'");
        public static readonly Error WhiteSpaceInConstant = new Error(103, 0, "Illegal whitespace in constant");
        public static readonly Error BadEscapeSequence = new Error(104, 0, "Bad escape sequence");
        public static readonly Error EmptyCharConstant = new Error(105, 0, "Empty char constant");
        public static readonly Error BadCharConstant = new Error(106, 0, "Missing ' in char constant");
        public static readonly Error IdentifierTooLong = new Error(108, 0, "Identifier too long");
        public static readonly Error NumericConstantOverflow = new Error(109, 0, "Numeric constant overflow");

        public static readonly Error UnexpectedEndOfFileStarSlash =
            new Error(110, 0, "Unexpected end of file found. '*/' expected.");

        public static readonly Error UnexpectedEndOfFileString =
            new Error(111, 0, "Unexpected end of file found. '\"' expected.");

        private LexError()
        {
        }
    }
}