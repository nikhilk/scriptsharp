// ConditionalExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

namespace DSharp.Compiler.ScriptModel.Expressions
{
    internal sealed class ConditionalExpression : Expression
    {
        public ConditionalExpression(Expression condition, Expression trueValue, Expression falseValue)
            : base(ExpressionType.Conditional, trueValue.EvaluatedType, trueValue.MemberMask)
        {
            Condition = condition;
            TrueValue = trueValue;
            FalseValue = falseValue;
        }

        protected override bool IsParenthesisRedundant => false;

        public Expression Condition { get; }

        public Expression FalseValue { get; }

        public override bool RequiresThisContext => TrueValue.RequiresThisContext || FalseValue.RequiresThisContext ||
                                                    Condition.RequiresThisContext;

        public Expression TrueValue { get; }
    }
}