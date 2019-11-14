using DSharp.Compiler.CodeModel.Members;

namespace DSharp.Compiler.ScriptModel.Symbols
{
    internal static class PropertySymbolExtensions
    {
        internal static PropertyDeclarationNode GetPropertyNode(this PropertySymbol propertySymbol)
        {
            return (PropertyDeclarationNode)propertySymbol?.ParseContext;
        }

        internal static bool IsAutoProperty(this PropertySymbol propertySymbol)
        {
            return propertySymbol?.GetPropertyNode()?.IsAutoProperty ?? false;
        }
    }
}
