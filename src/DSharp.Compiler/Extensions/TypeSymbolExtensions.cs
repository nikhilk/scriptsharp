using System;
using System.Collections.Generic;
using System.Linq;
using DSharp.Compiler.ScriptModel.Symbols;

namespace DSharp.Compiler.Extensions
{
    public static class TypeSymbolExtensions
    {
        private static readonly StringComparer stringComparer = StringComparer.InvariantCultureIgnoreCase;

        internal static ICollection<InterfaceSymbol> GetInterfaces(this TypeSymbol symbol)
        {
            if (symbol is ClassSymbol classSymbol)
            {
                return classSymbol.Interfaces ?? Array.Empty<InterfaceSymbol>();
            }

            if (symbol is InterfaceSymbol interfaceSymbol)
            {
                var interfaces = new List<InterfaceSymbol> { interfaceSymbol };

                if (interfaceSymbol.Interfaces != null)
                {
                    interfaces.AddRange(interfaceSymbol.Interfaces);
                }

                return interfaces;
            }

            return null;
        }

        internal static bool ImplementsListType(this TypeSymbol symbol)
        {
            var interfaces = symbol.GetInterfaces();

            if (interfaces == null)
            {
                return false;
            }

            return interfaces.Any(i => IsSpecifiedType(i, "System.Collections", "IList", "IList`1"));
        }

        internal static bool IsDictionary(this TypeSymbol symbol)
            => IsSpecifiedType(symbol, "System.Collections.Generic", "Dictionary`2");

        internal static bool IsList(this TypeSymbol symbol)
            => IsSpecifiedType(symbol, "System.Collections", "List", "List`1");

        internal static bool IsArgumentsType(this TypeSymbol symbol)
        {
            return symbol.FullName == "System.Arguments";
        }

        internal static bool IsNativeObject(this TypeSymbol typeSymbol)
        {
            return stringComparer.Equals(typeSymbol.FullGeneratedName, nameof(Object));
        }

        internal static bool IsReservedType(this TypeSymbol typeSymbol)
        {
            return typeSymbol.IsList() || typeSymbol.IsDictionary();
        }

        private static bool IsSpecifiedType(TypeSymbol typeSymbol, string ns, params string[] typeAliases)
        {
            return typeSymbol.FullName.StartsWith(ns)
                && typeAliases.Any(alias => typeSymbol.FullName.EndsWith(alias));
        }
    }
}
