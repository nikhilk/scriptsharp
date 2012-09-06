// InlineScriptExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal class InlineScriptExpression : Expression {

        private string _script;
        private Collection<Expression> _parameters;
        private bool _parenthesize;

        public InlineScriptExpression(string script, TypeSymbol evaluatedType)
            : this(script, evaluatedType, /* parenthesize */ true) {
        }

        public InlineScriptExpression(string script, TypeSymbol evaluatedType, bool parenthesize)
            : base(ExpressionType.InlineScript, evaluatedType, SymbolFilter.Public | SymbolFilter.InstanceMembers) {
            _script = script;
            _parenthesize = parenthesize;
        }

        protected override bool IsParenthesisRedundant {
            get {
                return !_parenthesize;
            }
        }

        public ICollection<Expression> Parameters {
            get {
                return _parameters;
            }
        }

        public override bool RequiresThisContext {
            get {
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

        public string Script {
            get {
                return _script;
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
