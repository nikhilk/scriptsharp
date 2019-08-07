// FieldExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.ScriptModel.Symbols;

namespace DSharp.Compiler.ScriptModel.Expressions
{
    internal class FieldExpression : Expression
    {
        public FieldExpression(Expression objectReference, FieldSymbol field)
            : this(ExpressionType.Field, objectReference, field)
        {
        }

        protected FieldExpression(ExpressionType type, Expression objectReference, FieldSymbol field)
            : base(type, field.AssociatedType, SymbolFilter.Public | SymbolFilter.InstanceMembers)
        {
            Field = field;
            ObjectReference = objectReference;
        }

        public FieldSymbol Field { get; }

        public Expression ObjectReference { get; }

        public override bool RequiresThisContext => ObjectReference.RequiresThisContext;
    }
}