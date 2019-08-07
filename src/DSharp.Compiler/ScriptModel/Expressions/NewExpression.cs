// NewExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections.Generic;
using System.Collections.ObjectModel;
using DSharp.Compiler.ScriptModel.Symbols;

namespace DSharp.Compiler.ScriptModel.Expressions
{
    internal sealed class NewExpression : Expression
    {
        private Collection<Expression> parameters;

        public NewExpression(TypeSymbol associatedType)
            : base(ExpressionType.New, associatedType, SymbolFilter.Public | SymbolFilter.InstanceMembers)
        {
            AssociatedType = associatedType;
        }

        public NewExpression(Expression typeExpression, TypeSymbol associatedType)
            : base(ExpressionType.New, associatedType, SymbolFilter.Public | SymbolFilter.InstanceMembers)
        {
            TypeExpression = typeExpression;
            AssociatedType = associatedType;
        }

        public TypeSymbol AssociatedType { get; }

        public bool IsSpecificType => TypeExpression == null;

        public IList<Expression> Parameters => parameters;

        public override bool RequiresThisContext
        {
            get
            {
                if (TypeExpression != null && TypeExpression.RequiresThisContext)
                {
                    return true;
                }

                if (parameters != null)
                {
                    foreach (Expression expression in parameters)
                        if (expression.RequiresThisContext)
                        {
                            return true;
                        }
                }

                return false;
            }
        }

        public Expression TypeExpression { get; }

        public void AddParameterValue(Expression expression)
        {
            if (parameters == null)
            {
                parameters = new Collection<Expression>();
            }

            parameters.Add(expression);
        }
    }
}