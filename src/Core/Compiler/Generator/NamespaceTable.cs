// ScriptGenerator.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;

namespace ScriptSharp.Generator
{
    public class NamespaceTable
    {
        public string TableName { get; set; }

        public IDictionary<string, string> Namespaces { get; set; }

        public string GenerateNamespaceRequest(string namespaceName)
        {
            string namespacePropertyName;
            if(!Namespaces.TryGetValue(namespaceName, out namespacePropertyName))
            {
                return string.Empty;
            }

            return string.Format("{0}.{1}", TableName, namespacePropertyName);
        }
    }
}
