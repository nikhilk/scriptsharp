// PropertyExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.ScriptModel.Symbols;

namespace DSharp.Compiler.ScriptModel.Expressions
{
    internal sealed class PropertyExpression : Expression
    {
        public PropertyExpression(Expression objectReference, PropertySymbol property, bool getter)
            : base(getter ? ExpressionType.PropertyGet : ExpressionType.PropertySet, property.AssociatedType,
                SymbolFilter.Public | SymbolFilter.InstanceMembers)
        {
            Property = property;
            ObjectReference = objectReference;
        }

        public Expression ObjectReference { get; }

        public PropertySymbol Property { get; }

        public override bool RequiresThisContext => ObjectReference.RequiresThisContext;
    }
}