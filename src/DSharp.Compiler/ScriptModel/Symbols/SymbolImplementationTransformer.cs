// SymbolSetTransformer.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections.Generic;

namespace DSharp.Compiler.ScriptModel.Symbols
{
    internal sealed class SymbolImplementationTransformer
    {
        private readonly ISymbolTransformer transformer;

        public SymbolImplementationTransformer(ISymbolTransformer transformer)
        {
            this.transformer = transformer;
        }

        private void TransformScope(SymbolScope scope, List<Symbol> transformedSymbols)
        {
            foreach (Symbol symbol in ((ISymbolTable) scope).Symbols)
            {
                if (symbol.Type != SymbolType.Variable)
                {
                    continue;
                }

                bool dummy;
                string transformedName = transformer.TransformSymbol(symbol, out dummy);

                if (transformedName != null)
                {
                    symbol.SetTransformedName(transformedName);
                    transformedSymbols.Add(symbol);
                }
            }

            if (scope.ChildScopes != null)
            {
                foreach (SymbolScope childScope in scope.ChildScopes) TransformScope(childScope, transformedSymbols);
            }
        }

        public ICollection<Symbol> TransformSymbolImplementation(SymbolImplementation implementation)
        {
            List<Symbol> transformedSymbols = new List<Symbol>();

            SymbolScope scope = implementation.Scope;
            TransformScope(scope, transformedSymbols);

            return transformedSymbols;
        }
    }
}