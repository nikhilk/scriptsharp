// DelegateInvokeExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal sealed class DelegateInvokeExpression : MethodExpression {

        public DelegateInvokeExpression(MethodExpression methodExpression)
            : base(ExpressionType.DelegateInvoke, methodExpression.ObjectReference, methodExpression.Method, methodExpression.GetParameters()) {
        }
    }
}
