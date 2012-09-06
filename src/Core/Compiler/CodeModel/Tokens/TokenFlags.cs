// TokenFlags.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;

namespace ScriptSharp.CodeModel {

    [Flags]
    internal enum TokenFlags {

        None = 0,

        PredefinedType = 1,

        AssignmentOperator = 2,

        OverloadableOperator = 4,
    }
}
