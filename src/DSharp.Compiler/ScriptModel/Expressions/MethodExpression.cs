// MethodExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections.Generic;
using System.Collections.ObjectModel;
using DSharp.Compiler.ScriptModel.Symbols;

namespace DSharp.Compiler.ScriptModel.Expressions
{
    internal class MethodExpression : Expression
    {
        private readonly Collection<Expression> parameters;

        public MethodExpression(Expression objectReference, MethodSymbol method)
            : this(ExpressionType.MethodInvoke, objectReference, method, null)
        {
        }

        protected MethodExpression(ExpressionType type, Expression objectReference, MethodSymbol method,
                                   Collection<Expression> parameters) :
            base(type,
                method.AssociatedType.Type == SymbolType.GenericParameter
                    ? objectReference.EvaluatedType
                    : method.AssociatedType,
                SymbolFilter.Public | SymbolFilter.InstanceMembers)
        {
            Method = method;
            ObjectReference = objectReference;
            this.parameters = parameters == null ? new Collection<Expression>() : parameters;
        }

        public MethodSymbol Method { get; }

        public IList<Expression> Parameters => parameters;

        public Expression ObjectReference { get; }

        public override bool RequiresThisContext
        {
            get
            {
                if (ObjectReference.RequiresThisContext)
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

        public bool IsExtensionMethod { get; set; }

        public void AddParameterValue(Expression expression)
        {
            parameters.Add(expression);
        }

        public Collection<Expression> GetParameters()
        {
            return parameters;
        }
    }
}
