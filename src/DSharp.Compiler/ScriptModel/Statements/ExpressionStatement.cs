// ExpressionStatement.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.ScriptModel.Expressions;

namespace DSharp.Compiler.ScriptModel.Statements
{
    internal sealed class ExpressionStatement : Statement
    {
        public ExpressionStatement(Expression expression)
            : this(expression, false)
        {
        }

        public ExpressionStatement(Expression expression, bool isFragment)
            : base(StatementType.Expression)
        {
            Expression = expression;
            IsFragment = isFragment;
        }

        public Expression Expression { get; }

        public bool IsFragment { get; }

        public override bool RequiresThisContext => Expression.RequiresThisContext;
    }
}