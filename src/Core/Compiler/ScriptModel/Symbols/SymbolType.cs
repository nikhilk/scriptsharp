// SymbolType.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;

namespace ScriptSharp.ScriptModel {

    internal enum SymbolType {

        Namespace = 0,

        Delegate = 1,

        Enumeration = 2,

        Resources = 3,

        Interface = 4,

        Record = 5,

        Class = 6,

        Field = 7,

        EnumerationField = 8,

        Constructor = 9,

        Property = 10,

        Indexer = 11,

        Event = 12,

        Method = 13,

        AnonymousMethod = 14,

        Variable = 15,

        Parameter = 16,

        GenericParameter = 17
    }
}
