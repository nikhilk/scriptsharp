// ExpressionNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Expressions
{
    internal abstract class ExpressionNode : ParseNode
    {
        protected ExpressionNode(ParseNodeType nodeType, Token token)
            : base(nodeType, token)
        {
        }

        public bool Parenthesized { get; private set; }

        public void AddParenthesisHint()
        {
            Parenthesized = true;
        }
    }
}