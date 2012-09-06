// NewExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal sealed class NewExpression : Expression {

        private TypeSymbol _associatedType;
        private Expression _typeExpression;
        private Collection<Expression> _parameters;

        public NewExpression(TypeSymbol associatedType)
            : base(ExpressionType.New, associatedType, SymbolFilter.Public | SymbolFilter.InstanceMembers) {
            _associatedType = associatedType;
        }

        public NewExpression(Expression typeExpression, TypeSymbol associatedType)
            : base(ExpressionType.New, associatedType, SymbolFilter.Public | SymbolFilter.InstanceMembers) {
            _typeExpression = typeExpression;
            _associatedType = associatedType;
        }

        public TypeSymbol AssociatedType {
            get {
                return _associatedType;
            }
        }

        public bool IsSpecificType {
            get {
                return (_typeExpression == null);
            }
        }

        public IList<Expression> Parameters {
            get {
                return _parameters;
            }
        }

        public override bool RequiresThisContext {
            get {
                if ((_typeExpression != null) && _typeExpression.RequiresThisContext) {
                    return true;
                }

                if (_parameters != null) {
                    foreach (Expression expression in _parameters) {
                        if (expression.RequiresThisContext) {
                            return true;
                        }
                    }
                }

                return false;
            }
        }

        public Expression TypeExpression {
            get {
                return _typeExpression;
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
