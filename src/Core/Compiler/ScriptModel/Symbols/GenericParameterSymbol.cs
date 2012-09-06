// GenericParameterSymbol.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal sealed class GenericParameterSymbol : TypeSymbol {

        private int _index;
        private bool _typeParameter;

        public GenericParameterSymbol(int index, string name, bool typeParameter, NamespaceSymbol parent)
            : base(SymbolType.GenericParameter, name, parent) {
            _index = index;
            _typeParameter = typeParameter;
        }

        public int Index {
            get {
                return _index;
            }
        }

        public bool IsTypeParameter {
            get {
                return _typeParameter;
            }
        }
    }
}
