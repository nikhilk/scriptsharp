// CastNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Expressions
{
    internal sealed class CastNode : ExpressionNode
    {
        public CastNode(Token token, ParseNode typeReference, ParseNode child)
            : base(ParseNodeType.Cast, token)
        {
            TypeReference = GetParentedNode(typeReference);
            Child = GetParentedNode(child);
        }

        public ParseNode Child { get; }

        public ParseNode TypeReference { get; }
    }
}