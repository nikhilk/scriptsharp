// LateBoundOperation.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;

namespace ScriptSharp.ScriptModel {

    internal enum LateBoundOperation {

        InvokeMethod = 0,

        GetField = 1,

        SetField = 2,

        DeleteField = 3,

        HasField = 4,

        HasMethod = 5,

        GetScriptType = 6,
    }
}
