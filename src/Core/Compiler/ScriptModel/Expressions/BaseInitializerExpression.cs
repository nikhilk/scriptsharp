// BaseInitializerExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal sealed class BaseInitializerExpression : Expression {

        private Collection<Expression> _parameters;

        public BaseInitializerExpression()
            : base(ExpressionType.BaseInitializer, null, 0) {
        }

        public ICollection<Expression> Parameters {
            get {
                return _parameters;
            }
        }

        public override bool RequiresThisContext {
            get {
                return true;
            }
        }

        public void AddParameterValue(Expression expression) {
            if (_parameters == null) {
                _parameters = new Collection<Expression>();
            }
            _parameters.Add(expression);
        }
    }
}
