// SymbolSetTransformer.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal sealed class SymbolSetTransformer {

        private ISymbolTransformer _transformer;
        private bool _excludeImportedTypes;

        public SymbolSetTransformer(ISymbolTransformer transformer)
            : this(transformer, /* excludeImportedTypes */ true) {
        }

        public SymbolSetTransformer(ISymbolTransformer transformer, bool excludeImportedTypes) {
            _transformer = transformer;
            _excludeImportedTypes = excludeImportedTypes;
        }

        public ICollection<Symbol> TransformSymbolSet(SymbolSet symbols, bool useInheritanceOrder) {
            List<TypeSymbol> symbolsToTransform = new List<TypeSymbol>();

            foreach (NamespaceSymbol ns in symbols.Namespaces) {
                if (_excludeImportedTypes && (ns.HasApplicationTypes == false)) {
                    continue;
                }

                foreach (TypeSymbol type in ns.Types) {
                    if (_excludeImportedTypes && (type.IsApplicationType == false)) {
                        continue;
                    }

                    symbolsToTransform.Add(type);
                }
            }

            if (useInheritanceOrder) {
                symbolsToTransform.Sort(new TypeInheritanceComparer());
            }

            List<Symbol> transformedSymbols = new List<Symbol>();
            foreach (TypeSymbol type in symbolsToTransform) {
                bool transformMembers;
                string transformedName = _transformer.TransformSymbol(type, out transformMembers);
                if (transformedName != null) {
                    type.SetTransformedName(transformedName);
                    transformedSymbols.Add(type);
                }

                if (transformMembers) {
                    bool dummy;
                    foreach (MemberSymbol member in type.Members) {
                        transformedName = _transformer.TransformSymbol(member, out dummy);
                        if (transformedName != null) {
                            member.SetTransformedName(transformedName);
                            transformedSymbols.Add(member);
                        }
                    }
                }
            }

            return transformedSymbols;
        }


        private sealed class TypeInheritanceComparer : IComparer<TypeSymbol> {

            public int Compare(TypeSymbol x, TypeSymbol y) {
                ClassSymbol class1 = x as ClassSymbol;
                ClassSymbol class2 = y as ClassSymbol;

                if ((class1 == null) && (class2 == null)) {
                    return 0;
                }

                if (class1 == null) {
                    return -1;
                }

                if (class2 == null) {
                    return 1;
                }

                int depth1 = class1.InheritanceDepth;
                int depth2 = class2.InheritanceDepth;

                return depth1 - depth2;
            }
        }
    }
}
