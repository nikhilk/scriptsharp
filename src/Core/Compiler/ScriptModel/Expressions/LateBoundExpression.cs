// LateBoundExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal sealed class LateBoundExpression : Expression {

        private LateBoundOperation _operation;
        private Expression _objectReference;
        private Expression _nameExpression;
        private Collection<Expression> _parameters;

        public LateBoundExpression(Expression objectReference, Expression nameExpression, LateBoundOperation operation, TypeSymbol evaluatedType)
            : base(ExpressionType.LateBound, evaluatedType, SymbolFilter.Public | SymbolFilter.InstanceMembers) {
            _objectReference = objectReference;
            _nameExpression = nameExpression;
            _operation = operation;

            _parameters = new Collection<Expression>();
        }

        public Expression NameExpression {
            get {
                return _nameExpression;
            }
        }

        public LateBoundOperation Operation {
            get {
                return _operation;
            }
        }

        public Expression ObjectReference {
            get {
                return _objectReference;
            }
        }

        public ICollection<Expression> Parameters {
            get {
                return _parameters;
            }
        }

        public override bool RequiresThisContext {
            get {
                if ((_objectReference != null) && _objectReference.RequiresThisContext) {
                    return true;
                }
                if (_nameExpression.RequiresThisContext) {
                    return true;
                }

                foreach (Expression expression in _parameters) {
                    if (expression.RequiresThisContext) {
                        return true;
                    }
                }

                return false;
            }
        }

        public void AddParameterValue(Expression expression) {
            _parameters.Add(expression);
        }
    }
}
