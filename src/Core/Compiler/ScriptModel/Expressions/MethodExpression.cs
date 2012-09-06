// MethodExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal class MethodExpression : Expression {

        private MethodSymbol _method;
        private Expression _objectReference;
        private Collection<Expression> _parameters;

        public MethodExpression(Expression objectReference, MethodSymbol method)
            : this(ExpressionType.MethodInvoke, objectReference, method, null) {
        }

        protected MethodExpression(ExpressionType type, Expression objectReference, MethodSymbol method, Collection<Expression> parameters) :
            base(type, (method.AssociatedType.Type == SymbolType.GenericParameter ? objectReference.EvaluatedType : method.AssociatedType),
                 SymbolFilter.Public | SymbolFilter.InstanceMembers) {
            _method = method;
            _objectReference = objectReference;
            _parameters = (parameters == null) ? new Collection<Expression>() : parameters;
        }

        public MethodSymbol Method {
            get {
                return _method;
            }
        }

        public IList<Expression> Parameters {
            get {
                return _parameters;
            }
        }

        public Expression ObjectReference {
            get {
                return _objectReference;
            }
        }

        public override bool RequiresThisContext {
            get {
                if (_objectReference.RequiresThisContext) {
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

        public Collection<Expression> GetParameters() {
            return _parameters;
        }
    }
}
