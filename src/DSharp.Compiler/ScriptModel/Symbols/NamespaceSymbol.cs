// NamespaceSymbol.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace DSharp.Compiler.ScriptModel.Symbols
{
    internal sealed class NamespaceSymbol : Symbol, ISymbolTable
    {
        private readonly Dictionary<string, TypeSymbol> typeMap;
        private readonly List<TypeSymbol> types;

        public NamespaceSymbol(string name, SymbolSet symbolSet)
            : base(SymbolType.Namespace, name, null)
        {
            SymbolSet = symbolSet;
            types = new List<TypeSymbol>();
            typeMap = new Dictionary<string, TypeSymbol>();
        }

        public bool HasApplicationTypes { get; private set; }

        public override SymbolSet SymbolSet { get; }

        public ICollection<TypeSymbol> Types => types;

        public void AddType(TypeSymbol typeSymbol)
        {
            Debug.Assert(typeSymbol != null);
            Debug.Assert(string.IsNullOrEmpty(typeSymbol.Name) == false);

            types.Add(typeSymbol);
            typeMap[typeSymbol.Name] = typeSymbol;

            if (typeSymbol.IsApplicationType)
            {
                HasApplicationTypes = true;
            }
        }

        public override bool MatchFilter(SymbolFilter filter)
        {
            if ((filter & SymbolFilter.Namespaces) == 0)
            {
                return false;
            }

            return true;
        }

        public ICollection Symbols => types;

        public Symbol FindSymbol(string name, Symbol context, SymbolFilter filter)
        {
            Debug.Assert(string.IsNullOrEmpty(name) == false);
            Debug.Assert(filter == SymbolFilter.Types);

            if (typeMap.ContainsKey(name))
            {
                return typeMap[name];
            }

            foreach(var type in types)
            {
                if((type as ISymbolTable).FindSymbol(name, context, filter | SymbolFilter.ExcludeParent) is Symbol result)
                {
                    return result;
                }
            }

            return null;
        }
    }
}
