// SymbolInternalizer.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal sealed class SymbolInternalizer : ISymbolTransformer {

        private static string GenerateName(string name) {
            if (name.StartsWith("_", StringComparison.OrdinalIgnoreCase) == false) {
                return "_" + Utility.CreateCamelCaseName(name);
            }
            return null;
        }

        private string TransformMember(MemberSymbol memberSymbol) {
            TypeSymbol type = (TypeSymbol)memberSymbol.Parent;
            if (((memberSymbol.Visibility & MemberVisibility.Public) != 0) ||
                ((memberSymbol.Visibility & MemberVisibility.Protected) != 0) ||
                (memberSymbol.IsTransformAllowed == false)) {
                return null;
            }
            if ((memberSymbol.Visibility & MemberVisibility.Internal) != 0) {
                return GenerateName(memberSymbol.Name);
            }
            else {
                // We add the inheritance depth, because two classes in the
                // same type hierarchy can have similar named private methods
                // which end up overriding each other in the generated script.
                // In release mode, these will get transformed into generated
                // names, so this type of disambiguation needs to be done for
                // debug builds only.
                int inheritanceDepth = 0;
                if (type.Type == SymbolType.Class) {
                    inheritanceDepth = ((ClassSymbol)type).InheritanceDepth;
                }
                if (inheritanceDepth != 0) {
                    string generatedName = GenerateName(memberSymbol.Name);
                    if (generatedName == null) {
                        // Can be null if the member was already prefixed with
                        // a "_"
                        generatedName = memberSymbol.Name;
                    }
                    return generatedName + "$" + inheritanceDepth;
                }
                return GenerateName(memberSymbol.Name);
            }
        }

        private string TransformType(TypeSymbol typeSymbol, out bool transformChildren) {
            transformChildren = (typeSymbol.Type != SymbolType.Interface) &&
                                (typeSymbol.Type != SymbolType.Delegate);

            if ((typeSymbol.Type == SymbolType.Enumeration) &&
                ((EnumerationSymbol)typeSymbol).UseNamedValues) {
                // If the enum uses named values, then don't transform, as its
                // unlikely the code wants to use some random generated name as the
                // named value.
                transformChildren = false;
            }

            if ((typeSymbol.IsPublic == false) && typeSymbol.IsTransformAllowed) {
                return GenerateName(typeSymbol.Name);
            }

            return null;
        }

        #region Implementation of ISymbolTransformer
        string ISymbolTransformer.TransformSymbol(Symbol symbol, out bool transformChildren) {
            transformChildren = false;

            if (symbol is TypeSymbol) {
                if ((symbol.Type == SymbolType.Class) && ((ClassSymbol)symbol).IsTestType) {
                    return null;
                }

                return TransformType((TypeSymbol)symbol, out transformChildren);
            }
            else if (symbol is MemberSymbol) {
                return TransformMember((MemberSymbol)symbol);
            }

            return null;
        }
        #endregion
    }
}
