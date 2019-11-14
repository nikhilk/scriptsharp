// SymbolInternalizer.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;

namespace DSharp.Compiler.ScriptModel.Symbols
{
    internal sealed class SymbolInternalizer : ISymbolTransformer
    {
        #region Implementation of ISymbolTransformer

        string ISymbolTransformer.TransformSymbol(Symbol symbol, out bool transformChildren)
        {
            transformChildren = false;

            if (symbol is TypeSymbol)
            {
                transformChildren = symbol.Type != SymbolType.Interface &&
                                    symbol.Type != SymbolType.Delegate;

                if (symbol.Type == SymbolType.Enumeration &&
                    ((EnumerationSymbol) symbol).UseNamedValues)
                {
                    // If the enum uses named values, then don't transform, as its
                    // unlikely the code wants to use some random generated name as the
                    // named value.
                    transformChildren = false;
                }

                return null;
            }

            if (symbol is MemberSymbol)
            {
                return TransformMember((MemberSymbol) symbol);
            }

            return null;
        }

        #endregion

        private static string GenerateName(string name)
        {
            if (name.StartsWith("_", StringComparison.OrdinalIgnoreCase) == false)
            {
                return "_" + Utility.CreateCamelCaseName(name);
            }

            return null;
        }

        private string TransformMember(MemberSymbol memberSymbol)
        {
            TypeSymbol type = (TypeSymbol) memberSymbol.Parent;

            if ((memberSymbol.Visibility & MemberVisibility.Public) != 0 ||
                (memberSymbol.Visibility & MemberVisibility.Protected) != 0 ||
                memberSymbol.Type == SymbolType.Property ||
                memberSymbol.IsTransformAllowed == false)
            {
                return null;
            }

            if ((memberSymbol.Visibility & MemberVisibility.Internal) != 0)
            {
                return GenerateName(memberSymbol.Name);
            }

            // We add the inheritance depth, because two classes in the
            // same type hierarchy can have similar named private methods
            // which end up overriding each other in the generated script.
            // In release mode, these will get transformed into generated
            // names, so this type of disambiguation needs to be done for
            // debug builds only.
            int inheritanceDepth = 0;

            if (type.Type == SymbolType.Class)
            {
                inheritanceDepth = ((ClassSymbol) type).InheritanceDepth;
            }

            if (inheritanceDepth != 0)
            {
                string generatedName = GenerateName(memberSymbol.Name);

                if (generatedName == null)
                {
                    // Can be null if the member was already prefixed with
                    // a "_"
                    generatedName = memberSymbol.Name;
                }

                return generatedName + "$" + inheritanceDepth;
            }

            return GenerateName(memberSymbol.Name);
        }
    }
}
