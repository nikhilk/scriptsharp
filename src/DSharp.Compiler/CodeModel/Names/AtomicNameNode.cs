// AtomicNameNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Names
{
    internal class AtomicNameNode : NameNode
    {
        public AtomicNameNode(IdentifierToken identifier)
            : this(ParseNodeType.Name, identifier)
        {
        }

        protected AtomicNameNode(ParseNodeType nodeType, IdentifierToken identifier)
            : base(nodeType, identifier)
        {
            Identifier = identifier;
        }

        public IdentifierToken Identifier { get; }

        protected sealed override ParseNodeList List => new ParseNodeList(this);
    }
}