// ForInStatement.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal sealed class ForInStatement : Statement {

        private VariableSymbol _dictionaryVariable;
        private VariableSymbol _loopVariable;
        private VariableSymbol _itemVariable;
        private Expression _collectionExpression;
        private Statement _body;

        private bool _dictionaryEnumeration;

        public ForInStatement(Expression collectionExpression)
            : this(collectionExpression, null) {
            _dictionaryEnumeration = false;
        }

        public ForInStatement(Expression collectionExpression, VariableSymbol dictionaryVariable)
            : base(StatementType.ForIn) {
            _collectionExpression = collectionExpression;
            _dictionaryVariable = dictionaryVariable;
            _dictionaryEnumeration = true;
        }

        public Statement Body {
            get {
                return _body;
            }
        }

        public Expression CollectionExpression {
            get {
                return _collectionExpression;
            }
        }

        public VariableSymbol DictionaryVariable {
            get {
                return _dictionaryVariable;
            }
        }

        public bool IsDictionaryEnumeration {
            get {
                return _dictionaryEnumeration;
            }
        }

        public VariableSymbol ItemVariable {
            get {
                return _itemVariable;
            }
        }

        public VariableSymbol LoopVariable {
            get {
                return _loopVariable;
            }
        }

        public override bool RequiresThisContext {
            get {
                return _collectionExpression.RequiresThisContext || _body.RequiresThisContext;
            }
        }

        public void AddBody(Statement statement) {
            Debug.Assert(_body == null);
            _body = statement;
        }

        public void SetItemVariable(VariableSymbol variable) {
            Debug.Assert(_itemVariable == null);
            _itemVariable = variable;
        }

        public void SetLoopVariable(VariableSymbol variable) {
            Debug.Assert(_loopVariable == null);
            _loopVariable = variable;
        }
    }
}
