// SymbolImplementation.cs
// Script#/Core/Compiler
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
        private string _thisIdentifier;

        public SymbolImplementation(ICollection<Statement> statements, SymbolScope scope, string thisIdentifier) {
            _scope = scope;
            _statements = statements;
            _thisIdentifier = thisIdentifier;
        }

        public bool DeclaresVariables {
            get {
                foreach (Statement statement in _statements) {
                    if (statement is VariableDeclarationStatement) {
                        return true;
                    }
                }
                return false;
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

        public SymbolScope Scope {
            get {
                return _scope;
            }
        }

        public ICollection<Statement> Statements {
            get {
                return _statements;
            }
        }

        public string ThisIdentifier {
            get {
                return _thisIdentifier;
            }
        }
    }
}
