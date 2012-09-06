// SwitchStatement.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal sealed class SwitchStatement : Statement {

        private Expression _condition;
        private List<SwitchGroup> _groups;

        public SwitchStatement(Expression condition)
            : base(StatementType.Switch) {
            _condition = condition;
            _groups = new List<SwitchGroup>();
        }

        public Expression Condition {
            get {
                return _condition;
            }
        }

        public ICollection<SwitchGroup> Groups {
            get {
                return _groups;
            }
        }

        public override bool RequiresThisContext {
            get {
                if (_condition.RequiresThisContext) {
                    return true;
                }

                foreach (SwitchGroup group in _groups) {
                    if (group.RequiresThisContext) {
                        return true;
                    }
                }

                return false;
            }
        }

        public void AddSwitchGroup(SwitchGroup group) {
            _groups.Add(group);
        }
    }
}
