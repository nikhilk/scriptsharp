// ISymbolTable.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

namespace DSharp.Compiler.ScriptModel.Symbols
{
    internal static class ISymbolTableExtensions
    {
        public static T FindSymbol<T>(this ISymbolTable table, string name, Symbol context, SymbolFilter filter)
            where T : Symbol
        {
            return (T)table.FindSymbol(name, context, filter);
        }
    }
}
