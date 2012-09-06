// UsingNamespaceNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal class UsingNamespaceNode : ParseNode {

        private NameNode _namespaceNameNode;

        public UsingNamespaceNode(Token token, NameNode namespaceName)
            : base(ParseNodeType.UsingNamespace, token) {
            _namespaceNameNode = (NameNode)GetParentedNode(namespaceName);
        }

        public string ReferencedNamespace {
            get {
                return _namespaceNameNode.Name;
            }
        }
    }
}
