// UnaryExpressionNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal sealed class UnaryExpressionNode : ExpressionNode {

        private ParseNode _child;

        public UnaryExpressionNode(Token op, ParseNode child)
            : base(ParseNodeType.UnaryExpression, op) {
            _child = GetParentedNode(child);
        }

        public ParseNode Child {
            get {
                return _child;
            }
        }

        public TokenType Operator {
            get {
                return Token.Type;
            }
        }
    }
}
