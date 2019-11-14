using System.Collections.Generic;

namespace DSharp.Compiler.ScriptModel.Expressions
{
    internal class ObjectInitializerExpression : Expression
    {
        public ObjectInitializerExpression(NewExpression newExpression, List<Expression> initializers)
            : base(ExpressionType.ObjectInitializer, newExpression.EvaluatedType, Symbols.SymbolFilter.All)
        {
            NewExpression = newExpression;
            Initializers = initializers;
        }

        internal NewExpression NewExpression { get; }

        internal List<Expression> Initializers { get; }
    }
}
