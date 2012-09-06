// LocalSymbol.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {
    
    internal sealed class VariableSymbol : LocalSymbol {

        private Expression _value;

        public VariableSymbol(string name, MemberSymbol parent, TypeSymbol valueType)
            : base(SymbolType.Variable, name, parent, valueType) {
        }

        public Expression Value {
            get {
                return _value;
            }
        }

        public void SetValue(Expression value) {
            _value = value;
        }
    }
}
