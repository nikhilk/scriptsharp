// SymbolScope.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace DSharp.Compiler.ScriptModel.Symbols
{
    internal sealed class SymbolScope : ISymbolTable
    {
        private readonly Collection<LocalSymbol> locals;

        private readonly Dictionary<string, LocalSymbol> localTable;

        private readonly ISymbolTable parentSymbolTable;
        private List<SymbolScope> childScopes;

        public SymbolScope(SymbolScope parentScope)
            : this((ISymbolTable) parentScope)
        {
            Parent = parentScope;
        }

        public SymbolScope(ISymbolTable parentSymbolTable)
        {
            Debug.Assert(parentSymbolTable != null);
            this.parentSymbolTable = parentSymbolTable;

            locals = new Collection<LocalSymbol>();
            localTable = new Dictionary<string, LocalSymbol>();
        }

        public ICollection<SymbolScope> ChildScopes => childScopes;

        public SymbolScope Parent { get; }

        public void AddChildScope(SymbolScope scope)
        {
            if (childScopes == null)
            {
                childScopes = new List<SymbolScope>();
            }

            childScopes.Add(scope);
        }

        public void AddSymbol(LocalSymbol symbol)
        {
            Debug.Assert(symbol != null);
            Debug.Assert(string.IsNullOrEmpty(symbol.Name) == false);
            Debug.Assert(localTable.ContainsKey(symbol.Name) == false);

            locals.Add(symbol);
            localTable[symbol.Name] = symbol;
        }

        #region ISymbolTable Members

        ICollection ISymbolTable.Symbols => locals;

        Symbol ISymbolTable.FindSymbol(string name, Symbol context, SymbolFilter filter)
        {
            Symbol symbol = null;

            if ((filter & SymbolFilter.Locals) != 0)
            {
                if (localTable.ContainsKey(name))
                {
                    symbol = localTable[name];
                }
            }

            if (symbol == null)
            {
                Debug.Assert(parentSymbolTable != null);
                symbol = parentSymbolTable.FindSymbol(name, context, filter);
            }

            return symbol;
        }

        #endregion
    }
}