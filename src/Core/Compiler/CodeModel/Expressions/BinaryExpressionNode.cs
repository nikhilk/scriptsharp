// ExpressionNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal sealed class BinaryExpressionNode : ExpressionNode {

        private TokenType _operatorType;
        private ParseNode _leftChild;
        private ParseNode _rightChild;

        public BinaryExpressionNode(ParseNode leftChild, TokenType operatorType, ParseNode rightChild)
            : base(ParseNodeType.BinaryExpression, leftChild.token) {
            _leftChild = GetParentedNode(leftChild);
            _operatorType = operatorType;
            _rightChild = GetParentedNode(rightChild);
        }

        public ParseNode LeftChild {
            get {
                return _leftChild;
            }
        }

        public TokenType Operator {
            get {
                return _operatorType;
            }
        }

        public ParseNode RightChild {
            get {
                return _rightChild;
            }
        }
    }
}
