// UsingAliasNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Names;
using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Types
{
    internal class UsingAliasNode : ParseNode
    {
        private readonly AtomicNameNode aliasName;
        private readonly NameNode typeName;

        public UsingAliasNode(Token token, AtomicNameNode name, NameNode type)
            : base(ParseNodeType.UsingAlias, token)
        {
            aliasName = (AtomicNameNode) GetParentedNode(name);
            typeName = (NameNode) GetParentedNode(type);
        }

        public string Alias => aliasName.Name;

        public string TypeName => typeName.Name;
    }
}