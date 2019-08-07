// ExpressionStatementNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

namespace DSharp.Compiler.CodeModel.Statements
{
    internal class ExpressionStatementNode : StatementNode
    {
        public ExpressionStatementNode(ParseNode expression)
            : base(ParseNodeType.ExpressionStatement, expression.Token)
        {
            Expression = GetParentedNode(expression);
        }

        public ParseNode Expression { get; }
    }
}