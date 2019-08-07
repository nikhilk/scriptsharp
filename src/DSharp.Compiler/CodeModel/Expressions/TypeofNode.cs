// TypeofNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Expressions
{
    internal sealed class TypeofNode : ExpressionNode
    {
        public TypeofNode(Token op, ParseNode typeReference)
            : base(ParseNodeType.Typeof, op)
        {
            TypeReference = GetParentedNode(typeReference);
        }

        public ParseNode TypeReference { get; }
    }
}