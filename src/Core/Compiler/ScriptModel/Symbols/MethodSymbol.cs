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

        private ICollection<string> _conditions;
        private bool _aliased;
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

        public SymbolImplementation Implementation {
            get {
                Debug.Assert(_implementation != null);
                return _implementation;
            }
        }

        public bool IsGeneric {
            get {
                return (_genericArguments != null) &&
                       (_genericArguments.Count != 0);
            }
        }

        public bool IsGlobalMethod {
            get {
                if (_aliased) {
                    // Methods with a script alias are considered global methods.
                    return true;
                }
                if (Parent.Type == SymbolType.Class) {
                    return ((ClassSymbol)Parent).HasGlobalMethods;
                }
                return false;
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
            Debug.Assert((Visibility & MemberVisibility.Static) != 0);

            SetTransformedName(alias);
            _aliased = true;
        }

        public void SetConditions(ICollection<string> conditions) {
            Debug.Assert(_conditions == null);
            Debug.Assert(conditions != null);

            _conditions = conditions;
        }

        public void SetSkipGeneration() {
            Debug.Assert(_skipGeneration == false);
            _skipGeneration = true;
        }
    }
}
