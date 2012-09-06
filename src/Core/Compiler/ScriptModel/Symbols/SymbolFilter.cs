// SymbolFilter.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;

namespace ScriptSharp.ScriptModel {

    [Flags]
    internal enum SymbolFilter {

        Locals = 1,

        Members = 2,

        Types = 4,

        Namespaces = 8,

        InstanceMembers = 32,

        StaticMembers = 64,

        Public = 128,

        Protected = 256,

        Private = 512,

        ExcludeParent = 1024,

        AllTypes = Locals | Members | Types | Namespaces,

        AnyMember = InstanceMembers | StaticMembers,

        AnyVisibility = Public | Protected | Private,

        All = AllTypes | AnyMember | AnyVisibility,
    }
}
