// LiteralExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    /// <summary>
    /// Represents constant values, null values, as well as type instances
    /// (eg. typeof(x))
    /// </summary>
    internal sealed class LiteralExpression : Expression {

        private object _value;

        public LiteralExpression(TypeSymbol valueType, object value)
            : base(ExpressionType.Literal, valueType, SymbolFilter.Public | SymbolFilter.InstanceMembers) {
            _value = value;
        }

        protected override bool IsParenthesisRedundant {
            get {
                // Numeric literals need to be paranthesized in script when followed by a
                // dot member access, so it is not redundant for numbers.

                if ((_value is String) || (_value is Boolean)) {
                    return true;
                }
                return false;
            }
        }

        public override bool RequiresThisContext {
            get {
                Expression[] items = _value as Expression[];
                if (items != null) {
                    foreach (Expression item in items) {
                        if (item.RequiresThisContext) {
                            return true;
                        }
                    }
                }

                return false;
            }
        }

        public object Value {
            get {
                return _value;
            }
        }
    }
}
