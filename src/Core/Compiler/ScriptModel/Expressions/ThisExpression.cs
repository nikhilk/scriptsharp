// ThisExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    /// <summary>
    /// Represents the class of the current type context.
    /// </summary>
    internal sealed class ThisExpression : Expression {

        private bool _explicitReference;

        public ThisExpression(ClassSymbol classSymbol, bool explicitReference)
            : base(ExpressionType.This, classSymbol, SymbolFilter.Public | SymbolFilter.Protected | SymbolFilter.Private | SymbolFilter.InstanceMembers) {
            _explicitReference = explicitReference;
        }

        public bool ExplicitReference {
            get {
                return _explicitReference;
            }
        }

        public override bool RequiresThisContext {
            get {
                return true;
            }
        }
    }
}
