// MemberVisibility.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;

namespace DSharp.Compiler.ScriptModel.Symbols
{
    [Flags]
    internal enum MemberVisibility
    {
        PrivateInstance = 0,

        Protected = 1,

        Public = 2,

        Internal = 4,

        Static = 8
    }
}