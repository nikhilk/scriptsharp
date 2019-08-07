// LiteralExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.ScriptModel.Symbols;

namespace DSharp.Compiler.ScriptModel.Expressions
{
    /// <summary>
    ///     Represents constant values, null values, as well as type instances
    ///     (eg. typeof(x))
    /// </summary>
    internal sealed class LiteralExpression : Expression
    {
        public LiteralExpression(TypeSymbol valueType, object value)
            : base(ExpressionType.Literal, valueType, SymbolFilter.Public | SymbolFilter.InstanceMembers)
        {
            Value = value;
        }

        protected override bool IsParenthesisRedundant
        {
            get
            {
                // Numeric literals need to be paranthesized in script when followed by a
                // dot member access, so it is not redundant for numbers.

                if (Value is string || Value is bool)
                {
                    return true;
                }

                return false;
            }
        }

        public override bool RequiresThisContext
        {
            get
            {
                Expression[] items = Value as Expression[];

                if (items != null)
                {
                    foreach (Expression item in items)
                        if (item.RequiresThisContext)
                        {
                            return true;
                        }
                }

                return false;
            }
        }

        public object Value { get; }
    }
}