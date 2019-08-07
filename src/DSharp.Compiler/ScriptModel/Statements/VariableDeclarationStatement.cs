// VariableDeclarationStatement.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections.Generic;
using DSharp.Compiler.ScriptModel.Symbols;

namespace DSharp.Compiler.ScriptModel.Statements
{
    internal sealed class VariableDeclarationStatement : Statement
    {
        private readonly List<VariableSymbol> variables;

        public VariableDeclarationStatement()
            : base(StatementType.VariableDeclaration)
        {
            variables = new List<VariableSymbol>();
        }

        public override bool RequiresThisContext
        {
            get
            {
                foreach (VariableSymbol variable in variables)
                    if (variable.Value != null &&
                        variable.Value.RequiresThisContext)
                    {
                        return true;
                    }

                return false;
            }
        }

        public ICollection<VariableSymbol> Variables => variables;

        public void AddVariable(VariableSymbol variable)
        {
            variables.Add(variable);
        }
    }
}