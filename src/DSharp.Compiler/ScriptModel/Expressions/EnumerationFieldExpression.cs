// FieldExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.ScriptModel.Symbols;

namespace DSharp.Compiler.ScriptModel.Expressions
{
    internal sealed class EnumerationFieldExpression : FieldExpression
    {
        public EnumerationFieldExpression(Expression objectReference, EnumerationFieldSymbol field)
            : base(ExpressionType.EnumerationField, objectReference, field)
        {
        }
    }
}