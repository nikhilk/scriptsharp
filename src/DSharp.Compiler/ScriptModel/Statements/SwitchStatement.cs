// SwitchStatement.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections.Generic;
using DSharp.Compiler.ScriptModel.Expressions;

namespace DSharp.Compiler.ScriptModel.Statements
{
    internal sealed class SwitchStatement : Statement
    {
        private readonly List<SwitchGroup> groups;

        public SwitchStatement(Expression condition)
            : base(StatementType.Switch)
        {
            Condition = condition;
            groups = new List<SwitchGroup>();
        }

        public Expression Condition { get; }

        public ICollection<SwitchGroup> Groups => groups;

        public override bool RequiresThisContext
        {
            get
            {
                if (Condition.RequiresThisContext)
                {
                    return true;
                }

                foreach (SwitchGroup group in groups)
                    if (group.RequiresThisContext)
                    {
                        return true;
                    }

                return false;
            }
        }

        public void AddSwitchGroup(SwitchGroup group)
        {
            groups.Add(group);
        }
    }
}