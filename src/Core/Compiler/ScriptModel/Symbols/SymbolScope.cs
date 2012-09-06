// SymbolScope.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal sealed class SymbolScope : ISymbolTable {

        private SymbolScope _parentScope;
        private ISymbolTable _parentSymbolTable;
        private List<SymbolScope> _childScopes;

        private Dictionary<string, LocalSymbol> _localTable;
        private Collection<LocalSymbol> _locals;

        public SymbolScope(SymbolScope parentScope)
            : this((ISymbolTable)parentScope) {
            _parentScope = parentScope;
        }

        public SymbolScope(ISymbolTable parentSymbolTable) {
            Debug.Assert(parentSymbolTable != null);
            _parentSymbolTable = parentSymbolTable;

            _locals = new Collection<LocalSymbol>();
            _localTable = new Dictionary<string, LocalSymbol>();
        }

        public ICollection<SymbolScope> ChildScopes {
            get {
                return _childScopes;
            }
        }

        public SymbolScope Parent {
            get {
                return _parentScope;
            }
        }

        public void AddChildScope(SymbolScope scope) {
            if (_childScopes == null) {
                _childScopes = new List<SymbolScope>();
            }
            _childScopes.Add(scope);
        }

        public void AddSymbol(LocalSymbol symbol) {
            Debug.Assert(symbol != null);
            Debug.Assert(String.IsNullOrEmpty(symbol.Name) == false);
            Debug.Assert(_localTable.ContainsKey(symbol.Name) == false);

            _locals.Add(symbol);
            _localTable[symbol.Name] = symbol;
        }

        #region ISymbolTable Members
        ICollection ISymbolTable.Symbols {
            get {
                return _locals;
            }
        }

        Symbol ISymbolTable.FindSymbol(string name, Symbol context, SymbolFilter filter) {
            Symbol symbol = null;

            if ((filter & SymbolFilter.Locals) != 0) {
                if (_localTable.ContainsKey(name)) {
                    symbol = _localTable[name];
                }
            }

            if (symbol == null) {
                Debug.Assert(_parentSymbolTable != null);
                symbol = _parentSymbolTable.FindSymbol(name, context, filter);
            }

            return symbol;
        }
        #endregion
    }
}
