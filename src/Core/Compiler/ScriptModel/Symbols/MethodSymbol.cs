// MethodSymbol.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ScriptSharp.ScriptModel {

    internal class MethodSymbol : CodeMemberSymbol {

        private string _alias;
        private ICollection<string> _conditions;
        private string _selector;
        private bool _skipGeneration;
        private ICollection<GenericParameterSymbol> _genericArguments;

        private SymbolImplementation _implementation;

        public MethodSymbol(string name, TypeSymbol parent, TypeSymbol returnType)
            : this(SymbolType.Method, name, parent, returnType) {
        }

        public MethodSymbol(string name, TypeSymbol parent, TypeSymbol returnType, MemberVisibility visibility)
            : this(SymbolType.Method, name, parent, returnType) {
            SetVisibility(visibility);
        }

        protected MethodSymbol(SymbolType type, string name, TypeSymbol parent, TypeSymbol returnType)
            : base(type, name, parent, returnType) {
        }

        public string Alias {
            get {
                return _alias;
            }
        }

        public ICollection<string> Conditions {
            get {
                return _conditions;
            }
        }

        public override string DocumentationID {
            get {
                TypeSymbol parent = (TypeSymbol)Parent;

                StringBuilder sb = new StringBuilder();
                sb.Append("M:");
                sb.Append(parent.Namespace);
                sb.Append(".");
                sb.Append(parent.Name);
                sb.Append(".");
                sb.Append(Name);

                if (Parameters != null) {
                    sb.Append("(");

                    for (int i = 0; i < Parameters.Count; i++) {
                        if (i > 0) {
                            sb.Append(",");
                        }

                        sb.Append(Parameters[i].DocumentationID);
                    }

                    sb.Append(")");
                }

                return sb.ToString();
            }
        }

        public ICollection<GenericParameterSymbol> GenericArguments {
            get {
                return _genericArguments;
            }
        }

        public bool HasSelector {
            get {
                return (_selector != null);
            }
        }

        public SymbolImplementation Implementation {
            get {
                Debug.Assert(_implementation != null);
                return _implementation;
            }
        }

        public bool IsAliased {
            get {
                return String.IsNullOrEmpty(_alias) == false;
            }
        }

        public bool IsExtension {
            get {
                if (Parent.Type == SymbolType.Class) {
                    return ((ClassSymbol)Parent).IsExtenderClass;
                }
                return false;
            }
        }

        public bool IsGeneric {
            get {
                return (_genericArguments != null) &&
                       (_genericArguments.Count != 0);
            }
        }

        public string Selector {
            get {
                Debug.Assert(_selector != null);
                return _selector;
            }
        }

        public bool SkipGeneration {
            get {
                return _skipGeneration;
            }
        }

        public void AddGenericArguments(ICollection<GenericParameterSymbol> genericArguments) {
            Debug.Assert(_genericArguments == null);
            Debug.Assert(genericArguments != null);
            Debug.Assert(genericArguments.Count != 0);

            _genericArguments = genericArguments;
        }

        public void AddImplementation(SymbolImplementation implementation) {
            Debug.Assert(_implementation == null);
            Debug.Assert(implementation != null);

            _implementation = implementation;
        }

        public bool MatchesConditions(ICollection<string> defines) {
            if (_conditions == null) {
                return true;
            }

            foreach (string condition in _conditions) {
                if (defines.Contains(condition)) {
                    return true;
                }
            }
            return false;
        }

        public void SetAlias(string alias) {
            Debug.Assert(_alias == null);
            Debug.Assert(String.IsNullOrEmpty(alias) == false);

            _alias = alias;
            SetTransformedName(alias);
        }

        public void SetConditions(ICollection<string> conditions) {
            Debug.Assert(_conditions == null);
            Debug.Assert(conditions != null);

            _conditions = conditions;
        }

        public void SetSelector(string selector) {
            Debug.Assert(_selector == null);
            Debug.Assert(String.IsNullOrEmpty(selector) == false);

            _selector = selector;
        }

        public void SetSkipGeneration() {
            Debug.Assert(_skipGeneration == false);
            _skipGeneration = true;
        }
    }
}
