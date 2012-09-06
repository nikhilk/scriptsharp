// EventExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal sealed class EventExpression : Expression {

        private EventSymbol _event;
        private Expression _objectReference;
        private Expression _handler;

        public EventExpression(Expression objectReference, EventSymbol eventSymbol, bool add)
            : base((add ? ExpressionType.EventAdd : ExpressionType.EventRemove), eventSymbol.AssociatedType, SymbolFilter.Public | SymbolFilter.InstanceMembers) {
            _event = eventSymbol;
            _objectReference = objectReference;
        }

        public EventSymbol Event {
            get {
                return _event;
            }
        }

        public Expression Handler {
            get {
                return _handler;
            }
        }

        public Expression ObjectReference {
            get {
                return _objectReference;
            }
        }

        public override bool RequiresThisContext {
            get {
                return _objectReference.RequiresThisContext || _handler.RequiresThisContext;
            }
        }

        public void SetHandler(Expression handler) {
            Debug.Assert(handler != null);
            Debug.Assert(_handler == null);

            _handler = handler;
        }
    }
}
