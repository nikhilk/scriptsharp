// BinaryExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.ScriptModel.Symbols;

namespace DSharp.Compiler.ScriptModel.Expressions
{
    internal sealed class BinaryExpression : Expression
    {
        public BinaryExpression(Operator operatorType, Expression leftOperand, Expression rightOperand)
            : this(operatorType, leftOperand, rightOperand, leftOperand.EvaluatedType)
        {
        }

        public BinaryExpression(Operator operatorType, Expression leftOperand, Expression rightOperand,
                                TypeSymbol evaluatedType)
            : base(ExpressionType.Binary, evaluatedType, SymbolFilter.Public | SymbolFilter.InstanceMembers)
        {
            Operator = operatorType;
            LeftOperand = leftOperand;
            RightOperand = rightOperand;
        }

        protected override bool IsParenthesisRedundant => false;

        public Expression LeftOperand { get; }

        public Operator Operator { get; }

        public override bool RequiresThisContext => LeftOperand.RequiresThisContext || RightOperand.RequiresThisContext;

        public Expression RightOperand { get; }
    }
}