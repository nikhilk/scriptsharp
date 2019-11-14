// SymbolSetTransformer.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections.Generic;

namespace DSharp.Compiler.ScriptModel.Symbols
{
    internal sealed class SymbolSetTransformer
    {
        private readonly bool excludeImportedTypes;

        private readonly ISymbolTransformer transformer;

        public SymbolSetTransformer(ISymbolTransformer transformer)
            : this(transformer, /* excludeImportedTypes */ true)
        {
        }

        public SymbolSetTransformer(ISymbolTransformer transformer, bool excludeImportedTypes)
        {
            this.transformer = transformer;
            this.excludeImportedTypes = excludeImportedTypes;
        }

        public void TransformSymbolSet(SymbolSet symbols, bool useInheritanceOrder)
        {
            List<TypeSymbol> symbolsToTransform = new List<TypeSymbol>();

            foreach (NamespaceSymbol ns in symbols.Namespaces)
            {
                if (excludeImportedTypes && ns.HasApplicationTypes == false)
                {
                    continue;
                }

                foreach (TypeSymbol type in ns.Types)
                {
                    if (excludeImportedTypes && type.IsApplicationType == false)
                    {
                        continue;
                    }

                    symbolsToTransform.Add(type);
                }
            }

            if (useInheritanceOrder)
            {
                symbolsToTransform.Sort(new TypeInheritanceComparer());
            }

            List<Symbol> transformedSymbols = new List<Symbol>();

            foreach (TypeSymbol type in symbolsToTransform)
            {
                string transformedName = transformer.TransformSymbol(type, out bool transformMembers);

                if (transformedName != null)
                {
                    type.SetTransformedName(transformedName);
                    transformedSymbols.Add(type);
                }

                if (transformMembers)
                {
                    bool dummy;

                    foreach (MemberSymbol member in type.Members)
                    {
                        transformedName = transformer.TransformSymbol(member, out dummy);

                        if (transformedName != null)
                        {
                            member.SetTransformedName(transformedName);
                            transformedSymbols.Add(member);
                        }
                    }
                }
            }
        }

        private sealed class TypeInheritanceComparer : IComparer<TypeSymbol>
        {
            public int Compare(TypeSymbol x, TypeSymbol y)
            {
                ClassSymbol class1 = x as ClassSymbol;
                ClassSymbol class2 = y as ClassSymbol;

                if (class1 == null && class2 == null)
                {
                    return 0;
                }

                if (class1 == null)
                {
                    return -1;
                }

                if (class2 == null)
                {
                    return 1;
                }

                int depth1 = class1.InheritanceDepth;
                int depth2 = class2.InheritanceDepth;

                return depth1 - depth2;
            }
        }
    }
}
