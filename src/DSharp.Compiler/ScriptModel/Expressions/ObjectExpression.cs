using System.Collections.Generic;
using DSharp.Compiler.ScriptModel.Symbols;

namespace DSharp.Compiler.ScriptModel.Expressions
{
    internal class ObjectExpression : Expression
    {
        public IDictionary<string, Expression> Properties { get; }

        public ObjectExpression(TypeSymbol evaluatedType, IDictionary<string, Expression> properties)
            : base(ExpressionType.Object, evaluatedType, SymbolFilter.AllTypes)
        {
            Properties = properties ?? new Dictionary<string, Expression>();
        }
    }
}
