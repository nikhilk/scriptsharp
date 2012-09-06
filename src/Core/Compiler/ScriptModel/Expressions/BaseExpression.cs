// BaseExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    /// <summary>
    /// Represents the base class of the current type context.
    /// </summary>
    internal sealed class BaseExpression : Expression {

        public BaseExpression(ClassSymbol classSymbol)
            : base(ExpressionType.Base, classSymbol, SymbolFilter.Public | SymbolFilter.Protected | SymbolFilter.InstanceMembers) {
        }

        public override bool RequiresThisContext {
            get {
                return true;
            }
        }
    }
}
