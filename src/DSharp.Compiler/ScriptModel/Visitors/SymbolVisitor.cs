using System.Linq;
using DSharp.Compiler.ScriptModel.Symbols;

namespace DSharp.Compiler.ScriptModel.Visitors
{
    internal abstract class SymbolVisitor
    {
        protected Symbol Visit(Symbol symbol)
        {
            if (symbol is TypeSymbol typeSymbol)
            {
                return VisitTypeSymbol(typeSymbol);
            }

            return symbol;
        }

        protected virtual TypeSymbol VisitTypeSymbol(TypeSymbol type)
        {
            if (type is ClassSymbol classSymbol)
            {
                return VisitClassSymbol(classSymbol);
            }
            else if (type is InterfaceSymbol interfaceSymbol)
            {
                return VisitInterfaceSymbol(interfaceSymbol);
            }

            return type;
        }

        protected virtual ClassSymbol VisitClassSymbol(ClassSymbol classSymbol)
        {
            foreach (var extendedInterfaceSymbol in classSymbol?.Interfaces ?? Enumerable.Empty<InterfaceSymbol>())
            {
                Visit(extendedInterfaceSymbol);
            }

            TypeSymbol baseType = classSymbol.GetBaseType();

            if (baseType != null)
            {
                Visit(baseType);
            }

            return classSymbol;
        }

        protected virtual InterfaceSymbol VisitInterfaceSymbol(InterfaceSymbol interfaceSymbol)
        {
            foreach (var extendedInterfaceSymbol in interfaceSymbol?.Interfaces ?? Enumerable.Empty<InterfaceSymbol>())
            {
                Visit(extendedInterfaceSymbol);
            }

            return interfaceSymbol;
        }
    }
}
