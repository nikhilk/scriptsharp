// FieldExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal class FieldExpression : Expression {

        private FieldSymbol _field;
        private Expression _objectReference;

        public FieldExpression(Expression objectReference, FieldSymbol field)
            : this(ExpressionType.Field, objectReference, field) {
        }

        protected FieldExpression(ExpressionType type, Expression objectReference, FieldSymbol field)
            : base(type, field.AssociatedType, SymbolFilter.Public | SymbolFilter.InstanceMembers) {
            _field = field;
            _objectReference = objectReference;
        }

        public FieldSymbol Field {
            get {
                return _field;
            }
        }

        public Expression ObjectReference {
            get {
                return _objectReference;
            }
        }

        public override bool RequiresThisContext {
            get {
                return _objectReference.RequiresThisContext;
            }
        }
    }
}
