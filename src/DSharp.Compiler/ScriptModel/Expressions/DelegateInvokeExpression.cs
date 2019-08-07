// DelegateInvokeExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

namespace DSharp.Compiler.ScriptModel.Expressions
{
    internal sealed class DelegateInvokeExpression : MethodExpression
    {
        public DelegateInvokeExpression(MethodExpression methodExpression)
            : base(ExpressionType.DelegateInvoke, methodExpression.ObjectReference, methodExpression.Method,
                methodExpression.GetParameters())
        {
        }
    }
}