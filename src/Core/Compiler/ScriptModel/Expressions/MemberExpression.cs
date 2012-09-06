// MemberExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal sealed class MemberExpression : Expression {

        private MemberSymbol _member;
        private Expression _objectReference;

        public MemberExpression(Expression objectReference, MemberSymbol member)
            : base(ExpressionType.Member, (member.AssociatedType.Type == SymbolType.GenericParameter ? objectReference.EvaluatedType : member.AssociatedType),
                   SymbolFilter.Public | SymbolFilter.InstanceMembers) {
            _member = member;
            _objectReference = objectReference;
        }

        public MemberSymbol Member {
            get {
                return _member;
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
