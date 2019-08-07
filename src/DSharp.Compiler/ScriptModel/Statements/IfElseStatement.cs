// IfElseStatement.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.ScriptModel.Expressions;

namespace DSharp.Compiler.ScriptModel.Statements
{
    internal sealed class IfElseStatement : Statement
    {
        public IfElseStatement(Expression condition, Statement ifStatement, Statement elseStatement)
            : base(StatementType.IfElse)
        {
            Condition = condition;
            IfStatement = ifStatement;
            ElseStatement = elseStatement;
        }

        public Expression Condition { get; }

        public Statement ElseStatement { get; }

        public Statement IfStatement { get; }

        public override bool RequiresThisContext
        {
            get
            {
                if (Condition.RequiresThisContext)
                {
                    return true;
                }

                if (IfStatement != null && IfStatement.RequiresThisContext)
                {
                    return true;
                }

                if (ElseStatement != null && ElseStatement.RequiresThisContext)
                {
                    return true;
                }

                return false;
            }
        }
    }
}