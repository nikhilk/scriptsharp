// ExpressionNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Expressions
{
    internal sealed class BinaryExpressionNode : ExpressionNode
    {
        public BinaryExpressionNode(ParseNode leftChild, TokenType operatorType, ParseNode rightChild)
            : base(ParseNodeType.BinaryExpression, leftChild.Token)
        {
            LeftChild = GetParentedNode(leftChild);
            Operator = operatorType;
            RightChild = GetParentedNode(rightChild);
        }

        public ParseNode LeftChild { get; }

        public TokenType Operator { get; }

        public ParseNode RightChild { get; }
    }
}