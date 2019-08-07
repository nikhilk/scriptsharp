// ForInStatement.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Diagnostics;
using DSharp.Compiler.ScriptModel.Expressions;
using DSharp.Compiler.ScriptModel.Symbols;

namespace DSharp.Compiler.ScriptModel.Statements
{
    internal sealed class ForInStatement : Statement
    {
        public ForInStatement(Expression collectionExpression)
            : this(collectionExpression, null)
        {
            IsDictionaryEnumeration = false;
        }

        public ForInStatement(Expression collectionExpression, VariableSymbol dictionaryVariable)
            : base(StatementType.ForIn)
        {
            CollectionExpression = collectionExpression;
            DictionaryVariable = dictionaryVariable;
            IsDictionaryEnumeration = true;
        }

        public Statement Body { get; private set; }

        public Expression CollectionExpression { get; }

        public VariableSymbol DictionaryVariable { get; }

        public bool IsDictionaryEnumeration { get; }

        public VariableSymbol ItemVariable { get; private set; }

        public VariableSymbol LoopVariable { get; private set; }

        public override bool RequiresThisContext =>
            CollectionExpression.RequiresThisContext || Body.RequiresThisContext;

        public void AddBody(Statement statement)
        {
            Debug.Assert(Body == null);
            Body = statement;
        }

        public void SetItemVariable(VariableSymbol variable)
        {
            Debug.Assert(ItemVariable == null);
            ItemVariable = variable;
        }

        public void SetLoopVariable(VariableSymbol variable)
        {
            Debug.Assert(LoopVariable == null);
            LoopVariable = variable;
        }
    }
}