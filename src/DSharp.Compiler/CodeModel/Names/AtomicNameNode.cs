// AtomicNameNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Names
{
    internal class AtomicNameNode : NameNode, IEquatable<AtomicNameNode>
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

        public bool Equals(AtomicNameNode other)
        {
            return other != null
                && other.Identifier.Type == Identifier.Type
                && other.Identifier.Identifier == Identifier.Identifier;
        }
    }
}
