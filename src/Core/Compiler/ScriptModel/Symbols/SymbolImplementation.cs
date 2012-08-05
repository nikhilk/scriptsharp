// SymbolImplementation.cs
// Script#/Core/ScriptSharp
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal sealed class SymbolImplementation {

        private SymbolScope _scope;
        private ICollection<Statement> _statements;

        public SymbolImplementation(ICollection<Statement> statements, SymbolScope scope) {
            _scope = scope;
            _statements = statements;
        }

        public SymbolScope Scope {
            get {
                return _scope;
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
    }
}
