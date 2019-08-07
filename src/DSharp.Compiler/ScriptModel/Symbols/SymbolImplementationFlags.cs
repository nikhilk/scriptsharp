// SymbolImplementationFlags.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;

namespace DSharp.Compiler.ScriptModel.Symbols
{
    [Flags]
    internal enum SymbolImplementationFlags
    {
        Regular = 0,

        Abstract = 1,

        Override = 2,

        Generated = 4,

        ReadOnly = 8
    }
}