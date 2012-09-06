// Statement.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal abstract class Statement {

        private StatementType _type;

        protected Statement(StatementType type) {
            _type = type;
        }

        public virtual bool RequiresThisContext {
            get {
                return false;
            }
        }

        public StatementType Type {
            get {
                return _type;
            }
        }
    }
}
