// SymbolImplementation.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections.Generic;
using DSharp.Compiler.ScriptModel.Statements;

namespace DSharp.Compiler.ScriptModel.Symbols
{
    internal sealed class SymbolImplementation
    {
        public SymbolImplementation(ICollection<Statement> statements, SymbolScope scope, string thisIdentifier)
        {
            Scope = scope;
            Statements = statements ?? System.Array.Empty<Statement>();
            ThisIdentifier = thisIdentifier;
        }

        public bool DeclaresVariables
        {
            get
            {
                foreach (Statement statement in Statements)
                    if (statement is VariableDeclarationStatement)
                    {
                        return true;
                    }

                return false;
            }
        }

        public bool RequiresThisContext
        {
            get
            {
                foreach (Statement statement in Statements)
                    if (statement.RequiresThisContext)
                    {
                        return true;
                    }

                return false;
            }
        }

        public SymbolScope Scope { get; }

        public ICollection<Statement> Statements { get; }

        public string ThisIdentifier { get; }
    }
}
