// Operator.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;

namespace ScriptSharp.ScriptModel {

    internal enum Operator {

        Plus = 0,

        PlusEquals = 1,

        Minus = 2,

        MinusEquals = 3,

        Multiply = 4,

        MultiplyEquals = 5,

        Divide = 6,

        DivideEquals = 7,

        Mod = 8,

        ModEquals = 9,

        EqualEqualEqual = 10,

        NotEqualEqual = 11,

        Less = 12,

        LessEqual = 13,

        Greater = 14,

        GreaterEqual = 15,

        LogicalOr = 16,

        LogicalAnd = 17,

        LogicalNot = 18,

        BitwiseOr = 19,

        BitwiseOrEquals = 20,

        BitwiseAnd = 21,

        BitwiseAndEquals = 22,

        BitwiseXor = 23,

        BitwiseXorEquals = 24,

        BitwiseNot = 25,

        ShiftLeft = 26,

        ShiftLeftEquals = 27,

        ShiftRight = 28,

        ShiftRightEquals = 29,

        UnsignedShiftRight = 30,

        UnsignedShiftRightEquals = 31,

        PreIncrement = 32,

        PreDecrement = 33,

        PostIncrement = 34,

        PostDecrement = 35,

        Equals = 36,

        Is = 37,

        As = 38,

        Negative = 39,

        Cast = 40,

        EqualEqual = 41,

        NotEqual = 42,

        Invalid = 43
    }
}
