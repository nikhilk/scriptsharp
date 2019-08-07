// ExpressionNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

namespace DSharp.Compiler.CodeModel.Expressions
{
    // NOTE: Not supported in conversion
    internal sealed class DefaultValueNode : ExpressionNode
    {
        public ParseNode Expression;

        public DefaultValueNode(ParseNode expression)
            : base(ParseNodeType.DefaultValueExpression, expression.Token)
        {
            Expression = expression;
        }
    }
}