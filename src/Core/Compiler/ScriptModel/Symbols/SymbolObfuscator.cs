// SymbolObfuscator.cs
// Script#/Core/ScriptSharp
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal sealed class SymbolObfuscator : ISymbolTransformer {

        private int _count;

        private static string GenerateName(int index, int offset) {
            if (offset == 0) {
                return String.Format("${0:X}", index);
            }
            return String.Format("${0:X}_{1:X}", offset, index);
        }

        private string TransformLocal(LocalSymbol localSymbol) {
            int depth = 0;

            AnonymousMethodSymbol parentMethod = localSymbol.Parent as AnonymousMethodSymbol;
            if (parentMethod != null) {
                // If an anonymous method contains a local variable with the
                // same name as a variable in the containing method, they will
                // conflict at runtime, i.e. the value in the inner method
                // will override the value of the outer method when it is run.
                // Note that right now we aren't seeing if there is actually a conflict.
                // We're always qualifying the inner variable with a depth prefix.
                // REVIEW: Should we try to optimize when we qualify?

                depth = parentMethod.Depth;
            }

            string transformedName = GenerateName(_count, depth);
            _count++;

            return transformedName;
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

        private string TransformType(TypeSymbol typeSymbol, out bool transformChildren) {
            string transformedName = null;
            transformChildren = (typeSymbol.Type != SymbolType.Interface) &&
                                (typeSymbol.Type != SymbolType.Delegate);

            if ((typeSymbol.IsPublic == false) && typeSymbol.IsTransformAllowed) {
                string prefix = typeSymbol.SymbolSet.ScriptPrefix;

                string name = String.Format("{0}${1:X}", prefix, _count);
                if ((typeSymbol.Name.Length + 1) < name.Length) {
                    transformedName = "_" + typeSymbol.Name;
                }
                else {
                    transformedName = name;
                    _count++;
                }
            }

            return transformedName;
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
            else if (symbol is LocalSymbol) {
                return TransformLocal((LocalSymbol)symbol);
            }

            return null;
        }
        #endregion
    }
}
