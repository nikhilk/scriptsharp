// ConditionalExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal sealed class ConditionalExpression : Expression {

        private Expression _trueValue;
        private Expression _falseValue;
        private Expression _condition;

        public ConditionalExpression(Expression condition, Expression trueValue, Expression falseValue)
            : base(ExpressionType.Conditional, trueValue.EvaluatedType, trueValue.MemberMask) {
            _condition = condition;
            _trueValue = trueValue;
            _falseValue = falseValue;
        }

        protected override bool IsParenthesisRedundant {
            get {
                return false;
            }
        }

        public Expression Condition {
            get {
                return _condition;
            }
        }

        public Expression FalseValue {
            get {
                return _falseValue;
            }
        }

        public override bool RequiresThisContext {
            get {
                return _trueValue.RequiresThisContext || _falseValue.RequiresThisContext ||
                       _condition.RequiresThisContext;
            }
        }

        public Expression TrueValue {
            get {
                return _trueValue;
            }
        }
    }
}
