// SymbolExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal sealed class LocalExpression : Expression {

        private LocalSymbol _symbol;

        public LocalExpression(LocalSymbol symbol)
            : this(symbol, SymbolFilter.Public | SymbolFilter.InstanceMembers) {
            _symbol = symbol;
        }

        public LocalExpression(LocalSymbol symbol, SymbolFilter memberMask)
            : base(ExpressionType.Local, symbol.ValueType, memberMask) {
            _symbol = symbol;
        }

        public LocalSymbol Symbol {
            get {
                return _symbol;
            }
        }
    }
}
