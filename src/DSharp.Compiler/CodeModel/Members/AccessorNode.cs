// AccessorNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Names;
using DSharp.Compiler.CodeModel.Statements;
using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Members
{
    internal sealed class AccessorNode : ParseNode
    {
        private readonly AtomicNameNode name;
        private ParseNodeList attributes;

        public AccessorNode(Token token,
                            ParseNodeList attributes,
                            AtomicNameNode name,
                            BlockStatementNode body,
                            Modifiers modifiers)
            : base(ParseNodeType.AccessorDeclaration, token)
        {
            this.name = (AtomicNameNode) GetParentedNode(name);
            Implementation = (BlockStatementNode) GetParentedNode(body);
            this.attributes = GetParentedNodeList(attributes);
            Modifiers = modifiers;
            IsAutoProperty = body == null;
        }

        public BlockStatementNode Implementation { get; }

        public Modifiers Modifiers { get; }

        public AccessorType Type
        {
            get
            {
                if (name.Name.Equals("get"))
                {
                    return AccessorType.Get;
                }

                return AccessorType.Set;
            }
        }

        public bool IsAutoProperty { get; }
    }
}
