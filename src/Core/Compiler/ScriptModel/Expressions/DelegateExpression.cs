// DelegateExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal sealed class DelegateExpression : Expression {

        private MethodSymbol _method;
        private Expression _objectReference;

        public DelegateExpression(Expression objectReference, MethodSymbol method)
            : base(ExpressionType.Delegate, method.AssociatedType, SymbolFilter.Public | SymbolFilter.InstanceMembers) {
            _method = method;
            _objectReference = objectReference;
        }

        public MethodSymbol Method {
            get {
                return _method;
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
