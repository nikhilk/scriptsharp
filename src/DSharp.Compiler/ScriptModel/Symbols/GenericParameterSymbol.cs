// GenericParameterSymbol.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

namespace DSharp.Compiler.ScriptModel.Symbols
{
    internal sealed class GenericParameterSymbol : ClassSymbol
    {
        public GenericParameterSymbol(int index, string name, bool typeParameter, NamespaceSymbol parent)
            : base(SymbolType.GenericParameter, name, parent)
        {
            Index = index;
            IsTypeParameter = typeParameter;
        }

        public int Index { get; }

        public bool IsTypeParameter { get; }
    }
}
