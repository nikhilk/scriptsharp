// EnumerationFieldSymbol.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

namespace DSharp.Compiler.ScriptModel.Symbols
{
    internal sealed class EnumerationFieldSymbol : FieldSymbol
    {
        public EnumerationFieldSymbol(string name, TypeSymbol parent, object value, TypeSymbol valueType)
            : base(SymbolType.EnumerationField, name, parent, valueType)
        {
            SetVisibility(MemberVisibility.Public | MemberVisibility.Static);
            Value = value;
        }
    }
}
