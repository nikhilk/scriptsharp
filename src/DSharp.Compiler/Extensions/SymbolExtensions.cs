using DSharp.Compiler.ScriptModel.Symbols;

namespace DSharp.Compiler.Extensions
{
    internal static class SymbolExtensions
    {
        internal static ClassSymbol GetFirstClassSymbolParent(this Symbol symbol)
        {
            var currentSymbol = symbol;

            while (currentSymbol != null)
            {
                if (currentSymbol is ClassSymbol classSymbol)
                {
                    return classSymbol;
                }

                currentSymbol = symbol.Parent;
            }

            return null;
        }
    }
}
