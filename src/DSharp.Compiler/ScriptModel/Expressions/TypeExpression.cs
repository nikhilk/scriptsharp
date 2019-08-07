// TypeExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.ScriptModel.Symbols;

namespace DSharp.Compiler.ScriptModel.Expressions
{
    /// <summary>
    ///     Represents a type which allows access to static members on the type
    ///     Note that this does not represent a Type object itself (eg. typeof(x));
    ///     Instead that is represented by a LiteralExpression.
    /// </summary>
    internal sealed class TypeExpression : Expression
    {
        public TypeExpression(TypeSymbol associatedType, SymbolFilter memberMask)
            : base(ExpressionType.Type, associatedType, memberMask)
        {
            AssociatedType = associatedType;
        }

        public TypeSymbol AssociatedType { get; }
    }
}