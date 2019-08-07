// EventExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Diagnostics;
using DSharp.Compiler.ScriptModel.Symbols;

namespace DSharp.Compiler.ScriptModel.Expressions
{
    internal sealed class EventExpression : Expression
    {
        public EventExpression(Expression objectReference, EventSymbol eventSymbol, bool add)
            : base(add ? ExpressionType.EventAdd : ExpressionType.EventRemove, eventSymbol.AssociatedType,
                SymbolFilter.Public | SymbolFilter.InstanceMembers)
        {
            Event = eventSymbol;
            ObjectReference = objectReference;
        }

        public EventSymbol Event { get; }

        public Expression Handler { get; private set; }

        public Expression ObjectReference { get; }

        public override bool RequiresThisContext => ObjectReference.RequiresThisContext || Handler.RequiresThisContext;

        public void SetHandler(Expression handler)
        {
            Debug.Assert(handler != null);
            Debug.Assert(Handler == null);

            Handler = handler;
        }
    }
}