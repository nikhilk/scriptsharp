// IndexerExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections.Generic;
using System.Collections.ObjectModel;
using DSharp.Compiler.ScriptModel.Symbols;

namespace DSharp.Compiler.ScriptModel.Expressions
{
    internal sealed class IndexerExpression : Expression
    {
        private readonly Collection<Expression> indices;

        public IndexerExpression(Expression objectReference, IndexerSymbol indexer)
            : base(ExpressionType.Indexer, indexer.AssociatedType, SymbolFilter.Public | SymbolFilter.InstanceMembers)
        {
            Indexer = indexer;
            ObjectReference = objectReference;

            indices = new Collection<Expression>();
        }

        public IndexerSymbol Indexer { get; }

        public ICollection<Expression> Indices => indices;

        public Expression ObjectReference { get; }

        public override bool RequiresThisContext
        {
            get
            {
                if (ObjectReference.RequiresThisContext)
                {
                    return true;
                }

                foreach (Expression expression in indices)
                    if (expression.RequiresThisContext)
                    {
                        return true;
                    }

                return false;
            }
        }

        public void AddIndexParameterValue(Expression expression)
        {
            indices.Add(expression);
        }
    }
}