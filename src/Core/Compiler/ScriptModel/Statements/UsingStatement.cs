// TryCatchFinallyStatement.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal sealed class UsingStatement : Statement {

        private VariableDeclarationStatement _guard;
        private Statement _body;

        public UsingStatement()
            : base(StatementType.Using) {
        }

        public VariableDeclarationStatement Guard {
            get {
                return _guard;
            }
        }

        public Statement Body
        {
            get
            {
                return _body;
            }
        }

        public override bool RequiresThisContext {
            get {
                if (_body.RequiresThisContext) {
                    return true;
                }
                return false;
            }
        }

        public void AddBody(Statement statement) {
            Debug.Assert(_body == null);
            _body = statement;
        }

        public void AddGuard(VariableDeclarationStatement guardStatement)
        {
            Debug.Assert(_guard == null);
            _guard = guardStatement;
        }
    }
}
