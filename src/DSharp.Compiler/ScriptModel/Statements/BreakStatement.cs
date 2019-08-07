// BreakStatement.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

namespace DSharp.Compiler.ScriptModel.Statements
{
    internal sealed class BreakStatement : Statement
    {
        public BreakStatement()
            : base(StatementType.Break)
        {
        }
    }
}