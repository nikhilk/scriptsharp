// BinaryExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal sealed class BinaryExpression : Expression {

        private Expression _leftOperand;
        private Expression _rightOperand;
        private Operator _operator;

        public BinaryExpression(Operator operatorType, Expression leftOperand, Expression rightOperand)
            : this(operatorType, leftOperand, rightOperand, leftOperand.EvaluatedType) {
        }

        public BinaryExpression(Operator operatorType, Expression leftOperand, Expression rightOperand, TypeSymbol evaluatedType)
            : base(ExpressionType.Binary, evaluatedType, SymbolFilter.Public | SymbolFilter.InstanceMembers) {
            _operator = operatorType;
            _leftOperand = leftOperand;
            _rightOperand = rightOperand;
        }

        protected override bool IsParenthesisRedundant {
            get {
                return false;
            }
        }

        public Expression LeftOperand {
            get {
                return _leftOperand;
            }
        }

        public Operator Operator {
            get {
                return _operator;
            }
        }

        public override bool RequiresThisContext {
            get {
                return _leftOperand.RequiresThisContext || _rightOperand.RequiresThisContext;
            }
        }

        public Expression RightOperand {
            get {
                return _rightOperand;
            }
        }
    }
}
