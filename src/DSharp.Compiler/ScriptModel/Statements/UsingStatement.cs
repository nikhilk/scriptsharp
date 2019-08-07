// TryCatchFinallyStatement.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Diagnostics;

namespace DSharp.Compiler.ScriptModel.Statements
{
    internal sealed class UsingStatement : Statement
    {
        public UsingStatement()
            : base(StatementType.Using)
        {
        }

        public VariableDeclarationStatement Guard { get; private set; }

        public Statement Body { get; private set; }

        public override bool RequiresThisContext
        {
            get
            {
                if (Body.RequiresThisContext)
                {
                    return true;
                }

                return false;
            }
        }

        public void AddBody(Statement statement)
        {
            Debug.Assert(Body == null);
            Body = statement;
        }

        public void AddGuard(VariableDeclarationStatement guardStatement)
        {
            Debug.Assert(Guard == null);
            Guard = guardStatement;
        }
    }
}