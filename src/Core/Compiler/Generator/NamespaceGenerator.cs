// NamespaceGenerator.cs
// Script#/Core/ScriptSharp
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using ScriptSharp;
using ScriptSharp.ScriptModel;

namespace ScriptSharp.Generator {

    internal static class NamespaceGenerator {

        public static void GenerateScript(ScriptGenerator generator, NamespaceSymbol namespaceSymbol, Dictionary<string,bool> generatedNamespaces) {
            Debug.Assert(generator != null);
            Debug.Assert(namespaceSymbol != null);
            Debug.Assert(namespaceSymbol.HasApplicationTypes);

            ScriptTextWriter writer = generator.Writer;

            // First generate enums and interfaces which do not have cross-dependencies
            // (Classes for example, might have dependencies on enums)

            foreach (TypeSymbol type in namespaceSymbol.Types) {
                if (type.IsApplicationType) {
                    if (type.IsTestType && (generator.Options.IncludeTests == false)) {
                        continue;
                    }

                    string namespaceName = type.GeneratedNamespace;
                    if ((namespaceName.Length != 0) &&
                        (generatedNamespaces.ContainsKey(namespaceName) == false)) {
                        writer.Write("Type.registerNamespace('");
                        writer.Write(namespaceName);
                        writer.Write("');");
                        writer.WriteNewLine();
                        writer.WriteNewLine();
                        generatedNamespaces[namespaceName] = true;
                    }
                }
                
                if (type.IsApplicationType &&
                    ((type.Type == SymbolType.Enumeration) ||
                     (type.Type == SymbolType.Interface) ||
                     (type.Type == SymbolType.Record) ||
                     (type.Type == SymbolType.Resources))) {
                    TypeGenerator.GenerateScript(generator, type);
                }
            }

            foreach (TypeSymbol type in namespaceSymbol.Types) {
                if (type.IsApplicationType && (type.Type == SymbolType.Class)) {
                    if (type.IsTestType && (generator.Options.IncludeTests == false)) {
                        continue;
                    }

                    TypeGenerator.GenerateScript(generator, type);
                }
            }
        }
    }
}
