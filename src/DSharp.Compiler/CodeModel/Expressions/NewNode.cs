// NewNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Expressions
{
    internal sealed class NewNode : ExpressionNode
    {
        public NewNode(Token token, ParseNode typeReference, ParseNode arguments)
            : base(ParseNodeType.New, token)
        {
            TypeReference = GetParentedNode(typeReference);
            Arguments = GetParentedNode(arguments);
        }

        public ParseNode Arguments { get; }

        public ParseNode TypeReference { get; set; }
    }
}