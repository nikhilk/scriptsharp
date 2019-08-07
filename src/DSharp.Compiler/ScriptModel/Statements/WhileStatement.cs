// WhileStatement.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.ScriptModel.Expressions;

namespace DSharp.Compiler.ScriptModel.Statements
{
    internal sealed class WhileStatement : Statement
    {
        public WhileStatement(Expression condition, Statement body, bool preCondition)
            : base(StatementType.While)
        {
            Condition = condition;
            Body = body;
            PreCondition = preCondition;
        }

        public Statement Body { get; }

        public Expression Condition { get; }

        public bool PreCondition { get; }

        public override bool RequiresThisContext
        {
            get
            {
                if (Body != null && Body.RequiresThisContext)
                {
                    return true;
                }

                if (Condition != null && Condition.RequiresThisContext)
                {
                    return true;
                }

                return false;
            }
        }
    }
}