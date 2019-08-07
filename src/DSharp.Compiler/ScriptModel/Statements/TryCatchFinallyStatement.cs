// TryCatchFinallyStatement.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Diagnostics;
using DSharp.Compiler.ScriptModel.Symbols;

namespace DSharp.Compiler.ScriptModel.Statements
{
    internal sealed class TryCatchFinallyStatement : Statement
    {
        public TryCatchFinallyStatement()
            : base(StatementType.TryCatchFinally)
        {
        }

        public Statement Body { get; private set; }

        public Statement Catch { get; private set; }

        public VariableSymbol ExceptionVariable { get; private set; }

        public Statement Finally { get; private set; }

        public override bool RequiresThisContext
        {
            get
            {
                if (Body.RequiresThisContext || Catch.RequiresThisContext)
                {
                    return true;
                }

                if (Finally != null)
                {
                    return Finally.RequiresThisContext;
                }

                return false;
            }
        }

        public void AddBody(Statement statement)
        {
            Debug.Assert(Body == null);
            Body = statement;
        }

        public void AddCatch(VariableSymbol exceptionVariable, Statement catchStatement)
        {
            Debug.Assert(ExceptionVariable == null);
            Debug.Assert(Catch == null);

            ExceptionVariable = exceptionVariable;
            Catch = catchStatement;
        }

        public void AddFinally(Statement finallyStatement)
        {
            Debug.Assert(Finally == null);
            Finally = finallyStatement;
        }
    }
}