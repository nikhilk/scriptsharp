// IfElseStatement.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal sealed class IfElseStatement : Statement {

        private Expression _condition;
        private Statement _ifStatement;
        private Statement _elseStatement;

        public IfElseStatement(Expression condition, Statement ifStatement, Statement elseStatement)
            : base(StatementType.IfElse) {
            _condition = condition;
            _ifStatement = ifStatement;
            _elseStatement = elseStatement;
        }

        public Expression Condition {
            get {
                return _condition;
            }
        }

        public Statement ElseStatement {
            get {
                return _elseStatement;
            }
        }

        public Statement IfStatement {
            get {
                return _ifStatement;
            }
        }

        public override bool RequiresThisContext {
            get {
                if (_condition.RequiresThisContext) {
                    return true;
                }
                if ((_ifStatement != null) && _ifStatement.RequiresThisContext) {
                    return true;
                }
                if ((_elseStatement != null) && _elseStatement.RequiresThisContext) {
                    return true;
                }
                return false;
            }
        }
    }
}
