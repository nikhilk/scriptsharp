// NamespaceTable.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;

namespace ScriptSharp.Generator
{
    public class NamespaceTable
    {
        public IDictionary<string, string> Namespaces { get; private set; }

        public NamespaceTable()
        {
            Namespaces = new Dictionary<string, string>();
        }

        public string GenerateNamespaceRequest(string namespaceName)
        {
            string namespacePropertyName = string.Empty;
            Namespaces.TryGetValue(namespaceName, out namespacePropertyName);

            return namespacePropertyName;
        }

        public void AddNamespace(string typeNamespace)
        {
            if(!string.IsNullOrWhiteSpace(typeNamespace) && !Namespaces.ContainsKey(typeNamespace))
            {
                Namespaces[typeNamespace] = GenerateNamespaceToken(typeNamespace);
            }
        }

        private string GenerateNamespaceToken(string typeNamespace)
        {
            return "ns_" + typeNamespace.Replace(".", "$");
        }
    }
}
