// ThisExpression.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.ScriptModel.Symbols;

namespace DSharp.Compiler.ScriptModel.Expressions
{
    /// <summary>
    ///     Represents the class of the current type context.
    /// </summary>
    internal sealed class ThisExpression : Expression
    {
        public ThisExpression(ClassSymbol classSymbol, bool explicitReference)
            : base(ExpressionType.This, classSymbol,
                SymbolFilter.Public | SymbolFilter.Protected | SymbolFilter.Private | SymbolFilter.InstanceMembers)
        {
            ExplicitReference = explicitReference;
        }

        public bool ExplicitReference { get; }

        public override bool RequiresThisContext => true;
    }
}