// FieldSymbol.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;
using System.Text;

namespace ScriptSharp.ScriptModel {
    
    internal class FieldSymbol : MemberSymbol {

        private bool _hasInitializer;
        private bool _isConstant;
        private bool _aliased;

        private object _value;

        private SymbolImplementation _implementation;

        public FieldSymbol(string name, TypeSymbol parent, TypeSymbol valueType)
            : this(SymbolType.Field, name, parent, valueType) {
        }

        protected FieldSymbol(SymbolType type, string name, TypeSymbol parent, TypeSymbol valueType)
            : base(type, name, parent, valueType) {
        }

        public override string DocumentationID {
            get {
                TypeSymbol parent = (TypeSymbol)Parent;

                StringBuilder sb = new StringBuilder();
                sb.Append("F:");
                sb.Append(parent.Namespace);
                sb.Append(".");
                sb.Append(parent.Name);
                sb.Append(".");
                sb.Append(Name);

                return sb.ToString();
            }
        }

        public bool HasInitializer {
            get {
                return _hasInitializer;
            }
        }

        public SymbolImplementation Implementation {
            get {
                Debug.Assert(_implementation != null);
                return _implementation;
            }
        }

        public bool IsConstant {
            get {
                return _isConstant;
            }
        }

        public bool IsGlobalField {
            get {
                return _aliased;
            }
        }

        public object Value {
            get {
                Debug.Assert(_value != null);
                return _value;
            }
            set {
                Debug.Assert(value != null);

                _value = value;
            }
        }

        public void AddImplementation(SymbolImplementation implementation) {
            Debug.Assert(_implementation == null);
            Debug.Assert(implementation != null);

            _implementation = implementation;
        }

        public void SetAlias(string alias) {
            Debug.Assert((Visibility & MemberVisibility.Static) != 0);

            SetTransformedName(alias);
            _aliased = true;
        }

        public void SetConstant() {
            // NOTE: This is only called for fields built from application
            //       code. We use this information to do const inlining
            //       which is scoped to consts defined within the assembly
            //       being compiled.

            Debug.Assert(_isConstant == false);
            _isConstant = true;
        }

        public void SetImplementationState(bool hasInitializer) {
            _hasInitializer = hasInitializer;
        }
    }
}
