using System;
using System.Collections.Generic;
using System.Linq;
using DSharp.Compiler.ScriptModel.Symbols;

namespace DSharp.Compiler.Extensions
{
    internal static class ClassSymbolExtensions
    {
        public static IEnumerable<string> GetNamespacesVisibleToClass(this ClassSymbol classSymbol)
        {
            if (classSymbol == null)
            {
                return Enumerable.Empty<string>();
            }

            var visibleNamespaces = new List<string>();

            if (classSymbol.Imports != null)
            {
                visibleNamespaces.AddRange(classSymbol.Imports);
            }

            if (classSymbol.Namespace != null)
            {
                visibleNamespaces.Add(classSymbol.Namespace);
                var namespaceParts = classSymbol.Namespace.Split('.').ToList();

                while (namespaceParts.Any())
                {
                    visibleNamespaces.Add(string.Join(".", namespaceParts));
                    namespaceParts.RemoveAt(namespaceParts.Count - 1);
                }
            }

            return visibleNamespaces.Distinct().ToArray();
        }
    }
}
