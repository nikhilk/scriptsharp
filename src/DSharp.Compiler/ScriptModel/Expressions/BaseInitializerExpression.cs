// BaseInitializerExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DSharp.Compiler.ScriptModel.Expressions
{
    internal sealed class BaseInitializerExpression : Expression
    {
        private Collection<Expression> parameters;

        public BaseInitializerExpression()
            : base(ExpressionType.BaseInitializer, null, 0)
        {
        }

        public ICollection<Expression> Parameters => parameters;

        public override bool RequiresThisContext => true;

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