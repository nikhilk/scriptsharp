// StatementType.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;

namespace ScriptSharp.ScriptModel {

    internal enum StatementType {

        Block = 0,

        Empty = 1,

        VariableDeclaration = 2,

        Return = 3,

        Expression = 4,

        IfElse = 5,

        While = 6,

        For = 7,

        ForIn = 8,

        Switch = 9,

        Break = 10,

        Continue = 11,

        Throw = 12,

        TryCatchFinally = 13,

        Error = 14,

        Using = 15
    }
}
