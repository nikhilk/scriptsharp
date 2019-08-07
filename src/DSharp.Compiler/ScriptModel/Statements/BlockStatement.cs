// BlockStatement.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections.Generic;

namespace DSharp.Compiler.ScriptModel.Statements
{
    internal sealed class BlockStatement : Statement
    {
        private readonly List<Statement> statements;

        public BlockStatement()
            : base(StatementType.Block)
        {
            statements = new List<Statement>();
        }

        public override bool RequiresThisContext
        {
            get
            {
                foreach (Statement statement in statements)
                    if (statement.RequiresThisContext)
                    {
                        return true;
                    }

                return false;
            }
        }

        public ICollection<Statement> Statements => statements;

        public void AddStatement(Statement statement)
        {
            statements.Add(statement);
        }
    }
}