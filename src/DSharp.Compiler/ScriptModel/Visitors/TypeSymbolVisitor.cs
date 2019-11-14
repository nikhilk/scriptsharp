using System;
using System.Collections.Generic;
using DSharp.Compiler.ScriptModel.Symbols;

namespace DSharp.Compiler.ScriptModel.Visitors
{
    internal static class TypeSymbolVisitor
    {
        public static IEnumerable<T> Visit<T>(TypeSymbol type, Func<TypeSymbol, T> selector)
        {
            return TypeSymbolVisitor<T>.Visit(type, selector);
        }
    }

    internal sealed class TypeSymbolVisitor<T> : SymbolVisitor
    {
        private readonly Func<TypeSymbol, T> selector;
        private readonly List<T> items = new List<T>();

        private TypeSymbolVisitor(Func<TypeSymbol, T> selector)
        {
            this.selector = selector;
        }

        public static IEnumerable<T> Visit(TypeSymbol type, Func<TypeSymbol, T> selector)
        {
            TypeSymbolVisitor<T> visitor = new TypeSymbolVisitor<T>(selector);
            visitor.Visit(type);

            return visitor.items;
        }

        protected override TypeSymbol VisitTypeSymbol(TypeSymbol type)
        {
            items.Add(selector(type));

            return base.VisitTypeSymbol(type);
        }
    }
}
