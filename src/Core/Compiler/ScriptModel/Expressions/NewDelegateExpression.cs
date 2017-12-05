// NewExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal sealed class NewDelegateExpression : Expression {

        private TypeSymbol _associatedType;
        private Expression _typeExpression;

        public NewDelegateExpression(TypeSymbol associatedType)
            : base(ExpressionType.NewDelegate, associatedType, SymbolFilter.Public | SymbolFilter.InstanceMembers) {

            Debug.Assert(associatedType.Type == SymbolType.Delegate);
            _associatedType = associatedType;
        }

        public NewDelegateExpression(Expression typeExpression, TypeSymbol associatedType)
            : base(ExpressionType.NewDelegate, associatedType, SymbolFilter.Public | SymbolFilter.InstanceMembers) {

            Debug.Assert(associatedType.Type == SymbolType.Delegate);
            _typeExpression = typeExpression;
            _associatedType = associatedType;
        }

        public TypeSymbol AssociatedType {
            get {
                return _associatedType;
            }
        }

        public bool IsSpecificType {
            get {
                return (_typeExpression == null);
            }
        }

        public override bool RequiresThisContext {
            get
            {
                if ((_typeExpression != null) && _typeExpression.RequiresThisContext) {
                    return true;
                }

                return false;
            }
        }

        protected override bool IsParenthesisRedundant {
            get {
                return false;
            }
        }

        public Expression TypeExpression {
            get {
                return _typeExpression;
            }
        }
    }
}
