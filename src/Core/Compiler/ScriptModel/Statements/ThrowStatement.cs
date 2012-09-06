// ThrowStatement.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal sealed class ThrowStatement : Statement {

        private Expression _value;

        public ThrowStatement(Expression value)
            : base(StatementType.Throw) {
            _value = value;
        }

        public override bool RequiresThisContext {
            get {
                if (_value != null) {
                    return _value.RequiresThisContext;
                }
                return false;
            }
        }

        public Expression Value {
            get {
                return _value;
            }
        }
    }
}
