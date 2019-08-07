using System;
using System.Collections.Generic;
using System.Linq;
using DSharp.Compiler.ScriptModel.Symbols;

namespace DSharp.Compiler.Extensions
{
    public static class TypeSymbolExtensions
    {
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

        internal static bool IsListType(this TypeSymbol symbol)
        {
            var interfaces = symbol.GetInterfaces();

            if (interfaces == null)
            {
                return false;
            }

            if (interfaces.Any(i => i.FullName.StartsWith("System.Collections")
                && (i.FullGeneratedName.EndsWith("IList") || i.FullGeneratedName.EndsWith("IList`1"))))
            {
                return true;
            }

            return false;
        }

        internal static bool IsArgumentsType(this TypeSymbol symbol)
        {
            return symbol.FullName == "System.Arguments";
        }
    }
}
