// VariableDeclarationStatement.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal sealed class VariableDeclarationStatement : Statement {

        private List<VariableSymbol> _variables;

        public VariableDeclarationStatement()
            : base(StatementType.VariableDeclaration) {
            _variables = new List<VariableSymbol>();
        }

        public override bool RequiresThisContext {
            get {
                foreach (VariableSymbol variable in _variables) {
                    if ((variable.Value != null) &&
                        variable.Value.RequiresThisContext) {
                        return true;
                    }
                }
                return false;
            }
        }

        public ICollection<VariableSymbol> Variables {
            get {
                return _variables;
            }
        }

        public void AddVariable(VariableSymbol variable) {
            _variables.Add(variable);
        }
    }
}
