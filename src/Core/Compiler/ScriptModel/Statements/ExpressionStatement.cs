// ExpressionStatement.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal sealed class ExpressionStatement : Statement {

        private Expression _expression;
        private bool _fragment;

        public ExpressionStatement(Expression expression)
            : this(expression, false) {
        }

        public ExpressionStatement(Expression expression, bool isFragment)
            : base(StatementType.Expression) {
            _expression = expression;
            _fragment = isFragment;
        }

        public Expression Expression {
            get {
                return _expression;
            }
        }

        public bool IsFragment {
            get {
                return _fragment;
            }
        }

        public override bool RequiresThisContext {
            get {
                return _expression.RequiresThisContext;
            }
        }
    }
}
