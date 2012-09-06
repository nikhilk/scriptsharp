// EnumerationFieldSymbol.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {
    
    internal sealed class EnumerationFieldSymbol : FieldSymbol {

        public EnumerationFieldSymbol(string name, TypeSymbol parent, object value, TypeSymbol valueType)
            : base(SymbolType.EnumerationField, name, parent, valueType) {
            SetVisibility(MemberVisibility.Public | MemberVisibility.Static);
            Value = value;
        }
    }
}
