// BlockStatement.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal sealed class BlockStatement : Statement {

        private List<Statement> _statements;

        public BlockStatement()
            : base(StatementType.Block) {
            _statements = new List<Statement>();
        }

        public override bool RequiresThisContext {
            get {
                foreach (Statement statement in _statements) {
                    if (statement.RequiresThisContext) {
                        return true;
                    }
                }

                return false;
            }
        }

        public ICollection<Statement> Statements {
            get {
                return _statements;
            }
        }

        public void AddStatement(Statement statement) {
            _statements.Add(statement);
        }
    }
}
