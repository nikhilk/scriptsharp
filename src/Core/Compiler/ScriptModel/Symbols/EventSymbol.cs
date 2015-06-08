// FieldSymbol.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;
using System.Text;

namespace ScriptSharp.ScriptModel {
    
    internal sealed class EventSymbol : CodeMemberSymbol {

        private string _addAccessor;
        private string _removeAccessor;

        private SymbolImplementation _adderImplementation;
        private SymbolImplementation _removerImplementation;

        public EventSymbol(string name, TypeSymbol parent, TypeSymbol handlerType)
            : base(SymbolType.Event, name, parent, handlerType) {
            ParameterSymbol valueParameter = new ParameterSymbol("value", this, handlerType, ParameterMode.In);
            AddParameter(valueParameter);
        }

        public string AddAccessor {
            get {
                return _addAccessor;
            }
        }

        public SymbolImplementation AdderImplementation {
            get {
                Debug.Assert(_adderImplementation != null);
                return _adderImplementation;
            }
        }

        public bool DefaultImplementation {
            get {
                return ((ImplementationFlags & SymbolImplementationFlags.Generated) != 0);
            }
        }

        public override string DocumentationID {
            get {
                TypeSymbol parent = (TypeSymbol)Parent;

                StringBuilder sb = new StringBuilder();
                sb.Append("E:");
                sb.Append(parent.Namespace);
                sb.Append(".");
                sb.Append(parent.Name);
                sb.Append(".");
                sb.Append(Name);

                return sb.ToString();
            }
        }

        public bool HasCustomAccessors {
            get {
                return (_addAccessor != null) && (_removeAccessor != null);
            }
        }

        public string RemoveAccessor {
            get {
                return _removeAccessor;
            }
        }

        public SymbolImplementation RemoverImplementation {
            get {
                Debug.Assert(_removerImplementation != null);
                return _removerImplementation;
            }
        }

        public void AddImplementation(SymbolImplementation implementation, bool adder) {
            Debug.Assert(implementation != null);

            if (adder) {
                Debug.Assert(_adderImplementation == null);
                _adderImplementation = implementation;
            }
            else {
                Debug.Assert(_removerImplementation == null);
                _removerImplementation = implementation;
            }
        }

        public void SetAccessors(string addAccessor, string removeAccessor) {
            Debug.Assert((_addAccessor == null) && (_removeAccessor == null));
            Debug.Assert(String.IsNullOrEmpty(addAccessor) == false);
            Debug.Assert(String.IsNullOrEmpty(removeAccessor) == false);

            _addAccessor = addAccessor;
            _removeAccessor = removeAccessor;
        }
    }
}
