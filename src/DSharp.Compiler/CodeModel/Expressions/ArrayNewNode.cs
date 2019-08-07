// ArrayNewNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Expressions
{
    internal sealed class ArrayNewNode : ExpressionNode
    {
        public ArrayNewNode(Token token,
                            ParseNode typeReference,
                            ParseNode expressionList,
                            ParseNode initializerExpression)
            : base(ParseNodeType.ArrayNew, token)
        {
            TypeReference = GetParentedNode(typeReference);
            ExpressionList = GetParentedNode(expressionList);
            InitializerExpression = GetParentedNode(initializerExpression);
        }

        public ParseNode ExpressionList { get; }

        public ParseNode InitializerExpression { get; }

        public ParseNode TypeReference { get; }
    }
}