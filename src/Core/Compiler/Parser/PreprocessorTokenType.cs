// PreprocessorTokenType.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;

namespace ScriptSharp.Parser {

    internal enum PreprocessorTokenType {
        Define,
        Undef,
        If,
        Elif,
        Else,
        Endif,
        Error,
        Warning,
        Line,
        Default,
        Hidden,
        True,
        False,
        Region,
        EndRegion,
        Pragma,

        Identifier,

        Int,
        String,
        Not,
        EqualEqual,
        NotEqual,
        And,
        Or,
        OpenParen,
        CloseParen,
        EndOfLine,
        Unknown,
        Invalid,

        Last,       // Must be last
    }
}
