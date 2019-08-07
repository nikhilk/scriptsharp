// UnaryExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.ScriptModel.Symbols;

namespace DSharp.Compiler.ScriptModel.Expressions
{
    internal sealed class UnaryExpression : Expression
    {
        public UnaryExpression(Operator operatorType, Expression operand)
            : this(operatorType, operand, operand.EvaluatedType, operand.MemberMask)
        {
        }

        public UnaryExpression(Operator operatorType, Expression operand, TypeSymbol evaluatedType,
                               SymbolFilter memberMask)
            : base(ExpressionType.Unary, evaluatedType, memberMask)
        {
            Operator = operatorType;
            Operand = operand;
        }

        protected override bool IsParenthesisRedundant => false;

        public Expression Operand { get; }

        public Operator Operator { get; }

        public override bool RequiresThisContext => Operand.RequiresThisContext;
    }
}