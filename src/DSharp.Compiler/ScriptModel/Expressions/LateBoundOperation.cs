// LateBoundOperation.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

namespace DSharp.Compiler.ScriptModel.Expressions
{
    internal enum LateBoundOperation
    {
        InvokeMethod = 0,

        GetField = 1,

        SetField = 2,

        DeleteField = 3,

        HasField = 4,

        HasMethod = 5,

        GetScriptType = 6
    }
}