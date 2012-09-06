// LocalSymbol.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {
    
    internal abstract class LocalSymbol : Symbol {

        private TypeSymbol _valueType;

        protected LocalSymbol(SymbolType type, string name, MemberSymbol parent, TypeSymbol valueType)
            : base(type, name, parent) {
            _valueType = valueType;
        }

        public TypeSymbol ValueType {
            get {
                return _valueType;
            }
        }

        public override bool MatchFilter(SymbolFilter filter) {
            if ((filter & SymbolFilter.Locals) == 0) {
                return false;
            }
            return true;
        }
    }
}
