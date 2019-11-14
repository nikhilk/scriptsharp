using System.Linq;
using Microsoft.CodeAnalysis;

namespace DSharp.CodeAnalysis
{
    public static class MethodSymbolExtensions
    {
        public static bool HasAttributeWithName(this IMethodSymbol methodSymbol, string name)
        {
            return methodSymbol
                .GetAttributes()
                .Any(a => a.AttributeClass.Name.Equals(name, System.StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
