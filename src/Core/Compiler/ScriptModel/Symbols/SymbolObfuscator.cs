// SymbolObfuscator.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal sealed class SymbolObfuscator : ISymbolTransformer {

        private static string GenerateName(int index, int offset) {
            // Shorten the name - the use of "$" ensures it won't conflict with a
            // name in the source code.

            string name = Utility.CreateEncodedName(index, /* useDigits */ true);

            if (offset == 0) {
                return "$" + name;
            }
            return Utility.CreateEncodedName(offset, /* useDigits */ false) + "$" + name;
        }

        private string TransformMember(MemberSymbol memberSymbol) {
            if ((memberSymbol.InterfaceMember != null) ||
                (memberSymbol.Name.Length < 3) ||
                (memberSymbol.IsTransformAllowed == false)) {
                // Interface members do get obfuscated

                // Also members with already short names do not get
                // obfuscated, as doing so might infact increase the name size
                return null;
            }

            TypeSymbol type = (TypeSymbol)memberSymbol.Parent;

            if (memberSymbol.IsPublic == false) {
                if ((memberSymbol is CodeMemberSymbol) &&
                    ((CodeMemberSymbol)memberSymbol).IsOverride) {
                    ClassSymbol baseType = ((ClassSymbol)type).BaseClass;

                    if (baseType == null) {
                        baseType = (ClassSymbol)((ISymbolTable)memberSymbol.SymbolSet.SystemNamespace).FindSymbol("Object", null, SymbolFilter.Types);
                        Debug.Assert(baseType != null);
                    }

                    MemberSymbol baseMember =
                        (MemberSymbol)((ISymbolTable)baseType).FindSymbol(memberSymbol.Name, type, SymbolFilter.Members);
                    Debug.Assert(baseMember != null);

                    return baseMember.GeneratedName;
                }
                else {
                    int minimizationDepth = 0;
                    int currentCount = -1;

                    if (type is ClassSymbol) {
                        currentCount = ((ClassSymbol)type).TransformationCookie;
                    }
                    else if (type is EnumerationSymbol) {
                        currentCount = ((EnumerationSymbol)type).TransformationCookie;
                    }

                    if (type is ClassSymbol) {
                        minimizationDepth = ((ClassSymbol)type).MinimizationDepth;

                        if (currentCount == -1) {
                            ClassSymbol baseClass = ((ClassSymbol)type).BaseClass;
                            if ((baseClass != null) && baseClass.IsApplicationType) {
                                // Set current count to the base classes transformation
                                // cookie, so the generated one will the next one in
                                // sequence
                                currentCount = baseClass.TransformationCookie;
                            }
                        }
                    }

                    currentCount++;
                    if (type is ClassSymbol) {
                        ((ClassSymbol)type).TransformationCookie = currentCount;
                    }
                    else if (type is EnumerationSymbol) {
                        ((EnumerationSymbol)type).TransformationCookie = currentCount;
                    }

                    return GenerateName(currentCount, minimizationDepth);
                }
            }

            return null;
        }

        #region Implementation of ISymbolTransformer
        string ISymbolTransformer.TransformSymbol(Symbol symbol, out bool transformChildren) {
            transformChildren = false;

            if (symbol is TypeSymbol) {
                transformChildren = (symbol.Type != SymbolType.Interface) &&
                                    (symbol.Type != SymbolType.Delegate);

                if ((symbol.Type == SymbolType.Enumeration) &&
                    ((EnumerationSymbol)symbol).UseNamedValues) {
                    // If the enum uses named values, then don't transform, as its
                    // unlikely the code wants to use some random generated name as the
                    // named value.
                    transformChildren = false;
                }

                if ((symbol.Type == SymbolType.Class) &&
                    ((ClassSymbol)symbol).IsExtenderClass) {
                    // Unlikely that classes adding members to another object contain
                    // members that should be renamed.
                    transformChildren = false;
                }

                return null;
            }
            else if (symbol is MemberSymbol) {
                return TransformMember((MemberSymbol)symbol);
            }

            return null;
        }
        #endregion
    }
}
