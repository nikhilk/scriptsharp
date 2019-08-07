// SwitchGroup.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections.Generic;
using DSharp.Compiler.ScriptModel.Expressions;

namespace DSharp.Compiler.ScriptModel.Statements
{
    internal sealed class SwitchGroup
    {
        private readonly List<Statement> statements;

        private List<Expression> cases;

        public SwitchGroup()
        {
            statements = new List<Statement>();
        }

        public ICollection<Expression> Cases => cases;

        public bool IncludeDefault { get; private set; }

        public bool RequiresThisContext
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

        public void AddCase(Expression caseValue)
        {
            if (cases == null)
            {
                cases = new List<Expression>();
            }

            cases.Add(caseValue);
        }

        public void AddDefaultCase()
        {
            IncludeDefault = true;
        }

        public void AddStatement(Statement statement)
        {
            statements.Add(statement);
        }
    }
}