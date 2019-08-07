// ConditionalNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

namespace DSharp.Compiler.CodeModel.Expressions
{
    internal sealed class ConditionalNode : ExpressionNode
    {
        public ConditionalNode(ParseNode condition, ParseNode trueValue, ParseNode falseValue)
            : base(ParseNodeType.Conditional, condition.Token)
        {
            Condition = GetParentedNode(condition);
            TrueValue = GetParentedNode(trueValue);
            FalseValue = GetParentedNode(falseValue);
        }

        public ParseNode Condition { get; }

        public ParseNode FalseValue { get; }

        public ParseNode TrueValue { get; }
    }
}