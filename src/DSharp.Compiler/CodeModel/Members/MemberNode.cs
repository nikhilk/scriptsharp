// MemberNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Members
{
    internal abstract class MemberNode : ParseNode
    {
        protected MemberNode(ParseNodeType nodeType, Token token)
            : base(nodeType, token)
        {
        }

        public abstract ParseNodeList Attributes { get; }

        public abstract Modifiers Modifiers { get; }

        public abstract string Name { get; }

        public abstract ParseNode Type { get; }
    }
}