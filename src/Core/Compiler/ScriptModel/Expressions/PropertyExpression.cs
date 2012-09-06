// PropertyExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal sealed class PropertyExpression : Expression {

        private PropertySymbol _property;
        private Expression _objectReference;

        public PropertyExpression(Expression objectReference, PropertySymbol property, bool getter)
            : base((getter ? ExpressionType.PropertyGet : ExpressionType.PropertySet), property.AssociatedType, SymbolFilter.Public | SymbolFilter.InstanceMembers) {
            _property = property;
            _objectReference = objectReference;
        }

        public Expression ObjectReference {
            get {
                return _objectReference;
            }
        }

        public PropertySymbol Property {
            get {
                return _property;
            }
        }

        public override bool RequiresThisContext {
            get {
                return _objectReference.RequiresThisContext;
            }
        }
    }
}
