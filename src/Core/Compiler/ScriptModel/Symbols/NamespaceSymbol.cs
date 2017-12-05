// NamespaceSymbol.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {
    
    internal sealed class NamespaceSymbol : Symbol, ISymbolTable {

        private SymbolSet _symbolSet;
        private List<TypeSymbol> _types;
        private Dictionary<string, TypeSymbol> _typeMap;
        private bool _hasApplicationTypes;

        public NamespaceSymbol(string name, SymbolSet symbolSet)
            : base(SymbolType.Namespace, name, null) {
            _symbolSet = symbolSet;
            _types = new List<TypeSymbol>();
            _typeMap = new Dictionary<string, TypeSymbol>();
        }

        public bool HasApplicationTypes {
            get {
                return _hasApplicationTypes;
            }
        }

        public override SymbolSet SymbolSet {
            get {
                return _symbolSet;
            }
        }

        public ICollection<TypeSymbol> Types {
            get {
                return _types;
            }
        }

        public void AddType(TypeSymbol typeSymbol) {
            Debug.Assert(typeSymbol != null);
            Debug.Assert(String.IsNullOrEmpty(typeSymbol.Name) == false);

            _types.Add(typeSymbol);
            _typeMap[typeSymbol.Name] = typeSymbol;

            if (typeSymbol.IsApplicationType) {
                _hasApplicationTypes = true;
            }
        }

        public override bool MatchFilter(SymbolFilter filter) {
            if ((filter & SymbolFilter.Namespaces) == 0) {
                return false;
            }
            return true;
        }

        #region ISymbolTable Members
        ICollection ISymbolTable.Symbols {
            get {
                return _types;
            }
        }

        Symbol ISymbolTable.FindSymbol(string name, Symbol context, SymbolFilter filter) {
            Debug.Assert(String.IsNullOrEmpty(name) == false);
            Debug.Assert(context == null);
            Debug.Assert(filter == SymbolFilter.Types);

            if (_typeMap.ContainsKey(name)) {
                return _typeMap[name];
            }

            return null;
        }
        #endregion
    }
}
