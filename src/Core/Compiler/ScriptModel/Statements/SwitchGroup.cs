// SwitchGroup.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal sealed class SwitchGroup {

        private List<Expression> _cases;
        private bool _includeDefault;
        private List<Statement> _statements;

        public SwitchGroup() {
            _statements = new List<Statement>();
        }

        public ICollection<Expression> Cases {
            get {
                return _cases;
            }
        }

        public bool IncludeDefault {
            get {
                return _includeDefault;
            }
        }

        public bool RequiresThisContext {
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

        public void AddCase(Expression caseValue) {
            if (_cases == null) {
                _cases = new List<Expression>();
            }
            _cases.Add(caseValue);
        }

        public void AddDefaultCase() {
            _includeDefault = true;
        }

        public void AddStatement(Statement statement) {
            _statements.Add(statement);
        }
    }
}
