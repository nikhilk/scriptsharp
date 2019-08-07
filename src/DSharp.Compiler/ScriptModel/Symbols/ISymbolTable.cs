// ISymbolTable.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections;

namespace DSharp.Compiler.ScriptModel.Symbols
{
    internal interface ISymbolTable
    {
        ICollection Symbols { get; }

        Symbol FindSymbol(string name, Symbol context, SymbolFilter filter);
    }
}
