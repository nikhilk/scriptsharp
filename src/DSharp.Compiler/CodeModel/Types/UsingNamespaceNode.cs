// UsingNamespaceNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Names;
using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Types
{
    internal class UsingNamespaceNode : ParseNode
    {
        private readonly NameNode namespaceNameNode;

        public UsingNamespaceNode(Token token, NameNode namespaceName)
            : base(ParseNodeType.UsingNamespace, token)
        {
            namespaceNameNode = (NameNode) GetParentedNode(namespaceName);
        }

        public string ReferencedNamespace => namespaceNameNode.Name;
    }
}