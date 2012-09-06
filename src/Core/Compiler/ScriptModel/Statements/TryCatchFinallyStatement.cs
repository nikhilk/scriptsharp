// TryCatchFinallyStatement.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal sealed class TryCatchFinallyStatement : Statement {

        private Statement _body;
        private VariableSymbol _exceptionVariable;
        private Statement _catch;
        private Statement _finally;

        public TryCatchFinallyStatement()
            : base(StatementType.TryCatchFinally) {
        }

        public Statement Body {
            get {
                return _body;
            }
        }

        public Statement Catch {
            get {
                return _catch;
            }
        }

        public VariableSymbol ExceptionVariable {
            get {
                return _exceptionVariable;
            }
        }

        public Statement Finally {
            get {
                return _finally;
            }
        }

        public override bool RequiresThisContext {
            get {
                if (_body.RequiresThisContext || _catch.RequiresThisContext) {
                    return true;
                }
                if (_finally != null) {
                    return _finally.RequiresThisContext;
                }
                return false;
            }
        }

        public void AddBody(Statement statement) {
            Debug.Assert(_body == null);
            _body = statement;
        }

        public void AddCatch(VariableSymbol exceptionVariable, Statement catchStatement) {
            Debug.Assert(_exceptionVariable == null);
            Debug.Assert(_catch == null);

            _exceptionVariable = exceptionVariable;
            _catch = catchStatement;
        }

        public void AddFinally(Statement finallyStatement) {
            Debug.Assert(_finally == null);
            _finally = finallyStatement;
        }
    }
}
