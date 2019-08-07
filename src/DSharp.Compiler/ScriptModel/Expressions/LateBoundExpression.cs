// LateBoundExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections.Generic;
using System.Collections.ObjectModel;
using DSharp.Compiler.ScriptModel.Symbols;

namespace DSharp.Compiler.ScriptModel.Expressions
{
    internal sealed class LateBoundExpression : Expression
    {
        private readonly Collection<Expression> parameters;

        public LateBoundExpression(Expression objectReference, Expression nameExpression, LateBoundOperation operation,
                                   TypeSymbol evaluatedType)
            : base(ExpressionType.LateBound, evaluatedType, SymbolFilter.Public | SymbolFilter.InstanceMembers)
        {
            ObjectReference = objectReference;
            NameExpression = nameExpression;
            Operation = operation;

            parameters = new Collection<Expression>();
        }

        public Expression NameExpression { get; }

        public LateBoundOperation Operation { get; }

        public Expression ObjectReference { get; }

        public ICollection<Expression> Parameters => parameters;

        public override bool RequiresThisContext
        {
            get
            {
                if (ObjectReference != null && ObjectReference.RequiresThisContext)
                {
                    return true;
                }

                if (NameExpression.RequiresThisContext)
                {
                    return true;
                }

                foreach (Expression expression in parameters)
                    if (expression.RequiresThisContext)
                    {
                        return true;
                    }

                return false;
            }
        }

        public void AddParameterValue(Expression expression)
        {
            parameters.Add(expression);
        }
    }
}