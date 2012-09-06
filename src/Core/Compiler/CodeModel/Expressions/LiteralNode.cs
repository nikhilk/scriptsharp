// LiteralNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal sealed class LiteralNode : ExpressionNode {

        public LiteralNode(Token token)
            : base(ParseNodeType.Literal, CreateLiteralToken(token)) {
        }

        public LiteralToken Literal {
            get {
                return (LiteralToken)Token;
            }
        }

        public object Value {
            get {
                return ((LiteralToken)Token).LiteralValue;
            }
        }

        private static LiteralToken CreateLiteralToken(Token token) {
            if (token.Type == TokenType.Null) {
                return new NullToken(token.SourcePath, token.Position);
            }
            else if (token.Type == TokenType.True) {
                return new BooleanToken(true, token.SourcePath, token.Position);
            }
            else if (token.Type == TokenType.False) {
                return new BooleanToken(false, token.SourcePath, token.Position);
            }
            else {
                Debug.Assert(token is LiteralToken);
                return (LiteralToken)token;
            }
        }
    }
}
