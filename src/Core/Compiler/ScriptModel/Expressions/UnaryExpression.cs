// UnaryExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal sealed class UnaryExpression : Expression {

        private Expression _operand;
        private Operator _operator;

        public UnaryExpression(Operator operatorType, Expression operand)
            : this(operatorType, operand, operand.EvaluatedType, operand.MemberMask) {
        }

        public UnaryExpression(Operator operatorType, Expression operand, TypeSymbol evaluatedType, SymbolFilter memberMask)
            : base(ExpressionType.Unary, evaluatedType, memberMask) {
            _operator = operatorType;
            _operand = operand;
        }

        protected override bool IsParenthesisRedundant {
            get {
                return false;
            }
        }

        public Expression Operand {
            get {
                return _operand;
            }
        }

        public Operator Operator {
            get {
                return _operator;
            }
        }

        public override bool RequiresThisContext {
            get {
                return _operand.RequiresThisContext;
            }
        }
    }
}
