// CodeMemberSymbol.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {
    
    internal abstract class CodeMemberSymbol : MemberSymbol {

        private List<ParameterSymbol> _parameters;
        private SymbolImplementationFlags _implementationFlags;

        private List<AnonymousMethodSymbol> _anonymousMethods;

        protected CodeMemberSymbol(SymbolType type, string name, TypeSymbol parent, TypeSymbol associatedType)
            : base(type, name, parent, associatedType) {
        }

        public IList<AnonymousMethodSymbol> AnonymousMethods {
            get {
                return _anonymousMethods;
            }
        }

        protected SymbolImplementationFlags ImplementationFlags {
            get {
                return _implementationFlags;
            }
        }

        public bool IsAbstract {
            get {
                return ((_implementationFlags & SymbolImplementationFlags.Abstract) != 0);
            }
        }

        public bool IsOverride {
            get {
                return ((_implementationFlags & SymbolImplementationFlags.Override) != 0);
            }
        }

        public IList<ParameterSymbol> Parameters {
            get {
                return _parameters;
            }
        }

        public virtual void AddAnonymousMethod(AnonymousMethodSymbol anonymousMethod) {
            Debug.Assert(anonymousMethod != null);

            if (_anonymousMethods == null) {
                _anonymousMethods = new List<AnonymousMethodSymbol>();
            }

            _anonymousMethods.Add(anonymousMethod);
        }

        public void AddParameter(ParameterSymbol parameterSymbol) {
            Debug.Assert(parameterSymbol != null);

            if (_parameters == null) {
                _parameters = new List<ParameterSymbol>();
            }
            _parameters.Add(parameterSymbol);
        }

        public void SetImplementationState(SymbolImplementationFlags implementationFlags) {
            Debug.Assert(_implementationFlags == SymbolImplementationFlags.Regular);
            _implementationFlags = implementationFlags;
        }
    }
}
