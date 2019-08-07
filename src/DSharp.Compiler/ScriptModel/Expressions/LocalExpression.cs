// SymbolExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.ScriptModel.Symbols;

namespace DSharp.Compiler.ScriptModel.Expressions
{
    internal sealed class LocalExpression : Expression
    {
        public LocalExpression(LocalSymbol symbol)
            : this(symbol, SymbolFilter.Public | SymbolFilter.InstanceMembers)
        {
            Symbol = symbol;
        }

        public LocalExpression(LocalSymbol symbol, SymbolFilter memberMask)
            : base(ExpressionType.Local, symbol.ValueType, memberMask)
        {
            Symbol = symbol;
        }

        public LocalSymbol Symbol { get; }
    }
}