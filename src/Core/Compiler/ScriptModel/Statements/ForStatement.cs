// ForStatement.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal sealed class ForStatement : Statement {

        private Expression _condition;
        private List<Expression> _initializers;
        private List<Expression> _increments;
        private VariableDeclarationStatement _variables;
        private Statement _body;

        public ForStatement()
            : base(StatementType.For) {
        }

        public Statement Body {
            get {
                return _body;
            }
        }

        public Expression Condition {
            get {
                return _condition;
            }
        }

        public bool HasScopeVariables {
            get {
                return (_variables != null);
            }
        }

        public ICollection<Expression> Increments {
            get {
                return _increments;
            }
        }

        public ICollection<Expression> Initializers {
            get {
                return _initializers;
            }
        }

        public override bool RequiresThisContext {
            get {
                if ((_body != null) && _body.RequiresThisContext) {
                    return true;
                }
                if ((_condition != null) && _condition.RequiresThisContext) {
                    return true;
                }
                if (_increments != null) {
                    foreach (Expression expression in _increments) {
                        if (expression.RequiresThisContext) {
                            return true;
                        }
                    }
                }
                if (_initializers != null) {
                    foreach (Expression expression in _initializers) {
                        if (expression.RequiresThisContext) {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        public VariableDeclarationStatement Variables {
            get {
                return _variables;
            }
        }

        public void AddBody(Statement statement) {
            Debug.Assert(_body == null);
            _body = statement;
        }

        public void AddCondition(Expression expression) {
            Debug.Assert(_condition == null);
            _condition = expression;
        }

        public void AddIncrement(Expression expression) {
            if (_increments == null) {
                _increments = new List<Expression>();
            }
            _increments.Add(expression);
        }

        public void AddInitializer(Expression expression) {
            Debug.Assert(_variables == null);
            if (_initializers == null) {
                _initializers = new List<Expression>();
            }
            _initializers.Add(expression);
        }

        public void AddInitializer(VariableDeclarationStatement variables) {
            Debug.Assert(_initializers == null);
            Debug.Assert(_variables == null);
            _variables = variables;
        }
    }
}
