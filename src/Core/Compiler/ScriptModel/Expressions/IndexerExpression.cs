// IndexerExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal sealed class IndexerExpression : Expression {

        private IndexerSymbol _indexer;
        private Expression _objectReference;
        private Collection<Expression> _indices;

        public IndexerExpression(Expression objectReference, IndexerSymbol indexer)
            : base(ExpressionType.Indexer, indexer.AssociatedType, SymbolFilter.Public | SymbolFilter.InstanceMembers) {
            _indexer = indexer;
            _objectReference = objectReference;

            _indices = new Collection<Expression>();
        }

        public IndexerSymbol Indexer {
            get {
                return _indexer;
            }
        }

        public ICollection<Expression> Indices {
            get {
                return _indices;
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

                foreach (Expression expression in _indices) {
                    if (expression.RequiresThisContext) {
                        return true;
                    }
                }

                return false;
            }
        }

        public void AddIndexParameterValue(Expression expression) {
            _indices.Add(expression);
        }
    }
}
