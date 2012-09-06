// Expression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal abstract class Expression {

        private ExpressionType _type;
        private TypeSymbol _evaluatedType;
        private SymbolFilter _memberMask;

        private bool _parenthesized;

        protected Expression(ExpressionType type, TypeSymbol evaluatedType, SymbolFilter memberMask) {
            _type = type;
            _evaluatedType = evaluatedType;
            _memberMask = memberMask | SymbolFilter.Members;
        }

        public TypeSymbol EvaluatedType {
            get {
                return _evaluatedType;
            }
        }

        protected virtual bool IsParenthesisRedundant {
            get {
                return true;
            }
        }

        public SymbolFilter MemberMask {
            get {
                return _memberMask;
            }
        }

        public bool Parenthesized {
            get {
                return _parenthesized;
            }
        }

        public virtual bool RequiresThisContext {
            get {
                return false;
            }
        }

        public ExpressionType Type {
            get {
                return _type;
            }
        }

        public void AddParenthesisHint() {
            if (IsParenthesisRedundant == false) {
                _parenthesized = true;
            }
        }

        public void Reevaluate(TypeSymbol evaluatedType) {
            _evaluatedType = evaluatedType;
        }
    }
}
