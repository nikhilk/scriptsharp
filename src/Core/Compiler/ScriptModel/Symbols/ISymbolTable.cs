// ISymbolTable.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;

namespace ScriptSharp.ScriptModel {

    internal interface ISymbolTable {

        ICollection Symbols {
            get;
        }

        Symbol FindSymbol(string name, Symbol context, SymbolFilter filter);
    }
}
