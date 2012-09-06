// WhileStatement.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal sealed class WhileStatement : Statement {

        private Expression _condition;
        private Statement _body;
        private bool _preCondition;

        public WhileStatement(Expression condition, Statement body, bool preCondition)
            : base(StatementType.While) {
            _condition = condition;
            _body = body;
            _preCondition = preCondition;
        }

        public Statement Body {
            get {
                return _body;
            }
        }

        public Expression Condition {
            get {
                return _condition;
            }
        }

        public bool PreCondition {
            get {
                return _preCondition;
            }
        }

        public override bool RequiresThisContext {
            get {
                if ((_body != null) && _body.RequiresThisContext) {
                    return true;
                }
                if ((_condition != null) && _condition.RequiresThisContext) {
                    return true;
                }
                return false;
            }
        }
    }
}
