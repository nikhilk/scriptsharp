// TypeParameterNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Names;

namespace DSharp.Compiler.CodeModel.Types
{
    // NOTE: Ignored in conversion
    internal sealed class TypeParameterNode : ParseNode
    {
        private ParseNodeList attributes;
        private AtomicNameNode name;

        public TypeParameterNode(ParseNodeList attributes, AtomicNameNode name)
            : base(ParseNodeType.TypeParameter, name.Token)
        {
            this.attributes = attributes;
            this.name = name;
        }

        internal AtomicNameNode NameNode => name;
    }
}
