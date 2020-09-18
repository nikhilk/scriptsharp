// SymbolObfuscator.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Diagnostics;

namespace DSharp.Compiler.ScriptModel.Symbols
{
    internal sealed class SymbolObfuscator : ISymbolTransformer
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

        private static string GenerateName(int index, int offset)
        {
            // Shorten the name - the use of "$" ensures it won't conflict with a
            // name in the source code.

            string name = Utility.CreateEncodedName(index, /* useDigits */ true);

            if (offset == 0)
            {
                return "$" + name;
            }

            return Utility.CreateEncodedName(offset, /* useDigits */ false) + "$" + name;
        }

        private string TransformMember(MemberSymbol memberSymbol)
        {
            if (memberSymbol.InterfaceMember != null ||
                memberSymbol.Name.Length < 3 ||
                memberSymbol.IsTransformAllowed == false)
            {
                // Interface members do get obfuscated

                // Also members with already short names do not get
                // obfuscated, as doing so might infact increase the name size
                return null;
            }

            TypeSymbol type = (TypeSymbol) memberSymbol.Parent;

            if (memberSymbol.IsPublic == false)
            {
                if (memberSymbol is CodeMemberSymbol &&
                    ((CodeMemberSymbol) memberSymbol).IsOverride)
                {
                    ClassSymbol baseType = ((ClassSymbol) type).BaseClass;

                    if (baseType == null)
                    {
                        baseType =
                            (ClassSymbol) ((ISymbolTable) memberSymbol.SymbolSet.SystemNamespace).FindSymbol("Object",
                                null, SymbolFilter.Types);
                        Debug.Assert(baseType != null);
                    }

                    MemberSymbol baseMember =
                        (MemberSymbol) ((ISymbolTable) baseType).FindSymbol(memberSymbol.Name, type,
                            SymbolFilter.Members);
                    Debug.Assert(baseMember != null);

                    return baseMember.GeneratedName;
                }

                int minimizationDepth = 0;
                int currentCount = -1;

                if (type is ClassSymbol)
                {
                    currentCount = ((ClassSymbol) type).TransformationCookie;
                }
                else if (type is EnumerationSymbol)
                {
                    currentCount = ((EnumerationSymbol) type).TransformationCookie;
                }

                if (type is ClassSymbol)
                {
                    minimizationDepth = ((ClassSymbol) type).MinimizationDepth;

                    if (currentCount == -1)
                    {
                        ClassSymbol baseClass = ((ClassSymbol) type).BaseClass;

                        // When minifying members from a generic base class, we should 
                        // fallback to the open generic version, since the correct 
                        // TransformationCookie is only available there
                        if (baseClass != null && baseClass.IsGeneric)
                        {
                            baseClass = baseClass.GenericType as ClassSymbol;
                        }

                        if (baseClass != null && baseClass.IsApplicationType)
                        {
                            // Set current count to the base classes transformation
                            // cookie, so the generated one will the next one in
                            // sequence
                            currentCount = baseClass.TransformationCookie;
                        }
                    }
                }

                currentCount++;

                if (type is ClassSymbol)
                {
                    ((ClassSymbol) type).TransformationCookie = currentCount;
                }
                else if (type is EnumerationSymbol)
                {
                    ((EnumerationSymbol) type).TransformationCookie = currentCount;
                }

                return GenerateName(currentCount, minimizationDepth);
            }

            return null;
        }
    }
}
