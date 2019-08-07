// NewExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Diagnostics;
using DSharp.Compiler.ScriptModel.Symbols;

namespace DSharp.Compiler.ScriptModel.Expressions
{
    internal sealed class NewDelegateExpression : Expression
    {
        public NewDelegateExpression(TypeSymbol associatedType)
            : base(ExpressionType.NewDelegate, associatedType, SymbolFilter.Public | SymbolFilter.InstanceMembers)
        {
            Debug.Assert(associatedType.Type == SymbolType.Delegate);
            AssociatedType = associatedType;
        }

        public NewDelegateExpression(Expression typeExpression, TypeSymbol associatedType)
            : base(ExpressionType.NewDelegate, associatedType, SymbolFilter.Public | SymbolFilter.InstanceMembers)
        {
            Debug.Assert(associatedType.Type == SymbolType.Delegate);
            TypeExpression = typeExpression;
            AssociatedType = associatedType;
        }

        public TypeSymbol AssociatedType { get; }

        public bool IsSpecificType => TypeExpression == null;

        public override bool RequiresThisContext
        {
            get
            {
                if (TypeExpression != null && TypeExpression.RequiresThisContext)
                {
                    return true;
                }

                return false;
            }
        }

        protected override bool IsParenthesisRedundant => false;

        public Expression TypeExpression { get; }
    }
}