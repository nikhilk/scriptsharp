// InlineScriptExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections.Generic;
using System.Collections.ObjectModel;
using DSharp.Compiler.ScriptModel.Symbols;

namespace DSharp.Compiler.ScriptModel.Expressions
{
    internal class InlineScriptExpression : Expression
    {
        private readonly bool parenthesize;

        private Collection<Expression> parameters;

        public InlineScriptExpression(string script, TypeSymbol evaluatedType)
            : this(script, evaluatedType, /* parenthesize */ true)
        {
        }

        public InlineScriptExpression(string script, TypeSymbol evaluatedType, bool parenthesize)
            : base(ExpressionType.InlineScript, evaluatedType, SymbolFilter.Public | SymbolFilter.InstanceMembers)
        {
            Script = script;
            this.parenthesize = parenthesize;
        }

        protected override bool IsParenthesisRedundant => !parenthesize;

        public ICollection<Expression> Parameters => parameters;

        public override bool RequiresThisContext
        {
            get
            {
                if (parameters != null)
                {
                    foreach (Expression expression in parameters)
                        if (expression.RequiresThisContext)
                        {
                            return true;
                        }
                }

                return false;
            }
        }

        public string Script { get; }

        public void AddParameterValue(Expression expression)
        {
            if (parameters == null)
            {
                parameters = new Collection<Expression>();
            }

            parameters.Add(expression);
        }
    }
}