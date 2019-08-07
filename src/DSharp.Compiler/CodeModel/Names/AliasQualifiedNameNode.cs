// AliasQualifiedNameNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

namespace DSharp.Compiler.CodeModel.Names
{
    internal sealed class AliasQualifiedNameNode : NameNode
    {
        private AtomicNameNode aliasName;
        private NameNode name;

        public AliasQualifiedNameNode(AtomicNameNode left, NameNode right)
            : base(ParseNodeType.AliasQualifiedName, left.Token)
        {
            aliasName = (AtomicNameNode) GetParentedNode(left);
            name = (NameNode) GetParentedNode(right);
        }

        protected override ParseNodeList List => new ParseNodeList(this);
    }
}