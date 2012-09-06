// TypeExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    /// <summary>
    /// Represents a type which allows access to static members on the type
    /// Note that this does not represent a Type object itself (eg. typeof(x));
    /// Instead that is represented by a LiteralExpression.
    /// </summary>
    internal sealed class TypeExpression : Expression {

        private TypeSymbol _associatedType;

        public TypeExpression(TypeSymbol associatedType, SymbolFilter memberMask)
            : base(ExpressionType.Type, associatedType, memberMask) {
            _associatedType = associatedType;
        }

        public TypeSymbol AssociatedType {
            get {
                return _associatedType;
            }
        }
    }
}
