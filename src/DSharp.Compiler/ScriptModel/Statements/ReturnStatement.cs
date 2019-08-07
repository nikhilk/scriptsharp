// ReturnStatement.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.ScriptModel.Expressions;

namespace DSharp.Compiler.ScriptModel.Statements
{
    internal sealed class ReturnStatement : Statement
    {
        public ReturnStatement(Expression value)
            : base(StatementType.Return)
        {
            Value = value;
        }

        public override bool RequiresThisContext
        {
            get
            {
                if (Value != null)
                {
                    return Value.RequiresThisContext;
                }

                return false;
            }
        }

        public Expression Value { get; }
    }
}