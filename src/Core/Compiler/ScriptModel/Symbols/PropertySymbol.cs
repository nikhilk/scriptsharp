// PropertySymbol.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;
using System.Text;

namespace ScriptSharp.ScriptModel {
    
    internal class PropertySymbol : CodeMemberSymbol {

        private SymbolImplementation _getterImplementation;
        private SymbolImplementation _setterImplementation;

        public PropertySymbol(string name, TypeSymbol parent, TypeSymbol propertyType)
            : this(SymbolType.Property, name, parent, propertyType) {
        }

        protected PropertySymbol(SymbolType type, string name, TypeSymbol parent, TypeSymbol propertyType)
            : base(type, name, parent, propertyType) {
        }

        public override string DocumentationID {
            get {
                TypeSymbol parent = (TypeSymbol)Parent;

                StringBuilder sb = new StringBuilder();
                sb.Append("P:");
                sb.Append(parent.Namespace);
                sb.Append(".");
                sb.Append(parent.Name);
                sb.Append(".");
                sb.Append(Name);

                return sb.ToString();
            }
        }

        public bool IsReadOnly {
            get {
                return ((ImplementationFlags & SymbolImplementationFlags.ReadOnly) != 0);
            }
        }

        public bool HasGetter
        {
            get {
                return _getterImplementation != null;
            }
        }

        public bool HasSetter
        {
            get {
                return _setterImplementation != null;
            }
        }

        public SymbolImplementation GetterImplementation {
            get {
                Debug.Assert(_getterImplementation != null);
                return _getterImplementation;
            }
        }

        public SymbolImplementation SetterImplementation {
            get {
                Debug.Assert(_setterImplementation != null);
                return _setterImplementation;
            }
        }

        public void AddImplementation(SymbolImplementation implementation, bool getter) {
            Debug.Assert(implementation != null);

            if (getter) {
                Debug.Assert(_getterImplementation == null);
                _getterImplementation = implementation;
            }
            else {
                Debug.Assert(_setterImplementation == null);
                _setterImplementation = implementation;
            }
        }
    }
}
