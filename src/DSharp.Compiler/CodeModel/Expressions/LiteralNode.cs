// LiteralNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Diagnostics;
using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Expressions
{
    internal sealed class LiteralNode : ExpressionNode
    {
        public LiteralNode(Token token)
            : base(ParseNodeType.Literal, CreateLiteralToken(token))
        {
        }

        public LiteralToken Literal => (LiteralToken) Token;

        public object Value => ((LiteralToken) Token).LiteralValue;

        private static LiteralToken CreateLiteralToken(Token token)
        {
            if (token.Type == TokenType.Null || token.Type == TokenType.Default)
            {
                return new NullToken(token.SourcePath, token.Position);
            }

            if (token.Type == TokenType.True)
            {
                return new BooleanToken(true, token.SourcePath, token.Position);
            }

            if (token.Type == TokenType.False)
            {
                return new BooleanToken(false, token.SourcePath, token.Position);
            }

            Debug.Assert(token is LiteralToken);

            return (LiteralToken) token;
        }
    }
}
