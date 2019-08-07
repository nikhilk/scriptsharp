// ResourcesSymbol.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

namespace DSharp.Compiler.ScriptModel.Symbols
{
    internal sealed class ResourcesSymbol : ClassSymbol
    {
        public ResourcesSymbol(string name, NamespaceSymbol parent)
            : base(SymbolType.Resources, name, parent)
        {
        }
    }
}