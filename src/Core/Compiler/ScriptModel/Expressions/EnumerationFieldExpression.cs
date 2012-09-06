// FieldExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal sealed class EnumerationFieldExpression : FieldExpression {

        public EnumerationFieldExpression(Expression objectReference, EnumerationFieldSymbol field)
            : base(ExpressionType.EnumerationField, objectReference, field) {
        }
    }
}
