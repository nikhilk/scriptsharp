// UnaryExpressionNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Expressions
{
    internal sealed class UnaryExpressionNode : ExpressionNode
    {
        public UnaryExpressionNode(Token op, ParseNode child)
            : base(ParseNodeType.UnaryExpression, op)
        {
            Child = GetParentedNode(child);
        }

        public ParseNode Child { get; }

        public TokenType Operator => Token.Type;
    }
}