namespace DSharp.Compiler.ScriptModel.Symbols
{
    internal static class MethodSymbolExtensions
    {
        public static int GetGeneratedParamsCount(this MethodSymbol methodSymbol)
        {
            int count = methodSymbol.Parameters.Count - 1;

            if (methodSymbol.IsGeneric && !methodSymbol.IgnoreGeneratedTypeArguments)
            {
                count++;
            }

            return count;
        }
    }
}
