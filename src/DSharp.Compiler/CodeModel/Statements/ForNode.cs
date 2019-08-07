// ForNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Statements
{
    internal sealed class ForNode : StatementNode
    {
        public ForNode(Token token,
                       ParseNode initializer,
                       ParseNode condition,
                       ParseNode increment,
                       ParseNode body)
            : base(ParseNodeType.For, token)
        {
            Initializer = GetParentedNode(initializer);
            Condition = GetParentedNode(condition);
            Increment = GetParentedNode(increment);
            Body = GetParentedNode(body);
        }

        public ParseNode Body { get; }

        public ParseNode Condition { get; }

        public ParseNode Increment { get; }

        public ParseNode Initializer { get; }
    }
}