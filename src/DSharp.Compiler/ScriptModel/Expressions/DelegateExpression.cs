// DelegateExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.ScriptModel.Symbols;

namespace DSharp.Compiler.ScriptModel.Expressions
{
    internal sealed class DelegateExpression : Expression
    {
        public DelegateExpression(Expression objectReference, MethodSymbol method)
            : base(ExpressionType.Delegate, method.AssociatedType, SymbolFilter.Public | SymbolFilter.InstanceMembers)
        {
            Method = method;
            ObjectReference = objectReference;
        }

        public MethodSymbol Method { get; }

        public Expression ObjectReference { get; }

        public override bool RequiresThisContext => ObjectReference.RequiresThisContext;
    }
}