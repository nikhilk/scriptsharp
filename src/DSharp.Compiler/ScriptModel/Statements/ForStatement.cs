// ForStatement.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections.Generic;
using System.Diagnostics;
using DSharp.Compiler.ScriptModel.Expressions;

namespace DSharp.Compiler.ScriptModel.Statements
{
    internal sealed class ForStatement : Statement
    {
        private List<Expression> increments;
        private List<Expression> initializers;

        public ForStatement()
            : base(StatementType.For)
        {
        }

        public Statement Body { get; private set; }

        public Expression Condition { get; private set; }

        public bool HasScopeVariables => Variables != null;

        public ICollection<Expression> Increments => increments;

        public ICollection<Expression> Initializers => initializers;

        public override bool RequiresThisContext
        {
            get
            {
                if (Body != null && Body.RequiresThisContext)
                {
                    return true;
                }

                if (Condition != null && Condition.RequiresThisContext)
                {
                    return true;
                }

                if (increments != null)
                {
                    foreach (Expression expression in increments)
                        if (expression.RequiresThisContext)
                        {
                            return true;
                        }
                }

                if (initializers != null)
                {
                    foreach (Expression expression in initializers)
                        if (expression.RequiresThisContext)
                        {
                            return true;
                        }
                }

                return false;
            }
        }

        public VariableDeclarationStatement Variables { get; private set; }

        public void AddBody(Statement statement)
        {
            Debug.Assert(Body == null);
            Body = statement;
        }

        public void AddCondition(Expression expression)
        {
            Debug.Assert(Condition == null);
            Condition = expression;
        }

        public void AddIncrement(Expression expression)
        {
            if (increments == null)
            {
                increments = new List<Expression>();
            }

            increments.Add(expression);
        }

        public void AddInitializer(Expression expression)
        {
            Debug.Assert(Variables == null);

            if (initializers == null)
            {
                initializers = new List<Expression>();
            }

            initializers.Add(expression);
        }

        public void AddInitializer(VariableDeclarationStatement variables)
        {
            Debug.Assert(initializers == null);
            Debug.Assert(Variables == null);
            Variables = variables;
        }
    }
}