// LateBoundOperation.cs
// Script#/Core/ScriptSharp
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;

namespace ScriptSharp.ScriptModel {

    internal enum LateBoundOperation {

        InvokeMethod = 0,

        GetField = 1,

        SetField = 2,

        DeleteField = 3,

        GetProperty = 4,

        SetProperty = 5,

        AddHandler = 6,

        RemoveHandler = 7,

        GetScriptType = 8,

        HasField = 9,

        HasMethod = 10,

        HasProperty = 11
    }
}
