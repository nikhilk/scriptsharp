// ArrayNewNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal sealed class ArrayNewNode : ExpressionNode {

        private ParseNode _typeReference;
        private ParseNode _expressionList;
        private ParseNode _initializerExpression;

        public ArrayNewNode(Token token,
                            ParseNode typeReference,
                            ParseNode expressionList,
                            ParseNode initializerExpression)
            : base(ParseNodeType.ArrayNew, token) {
            _typeReference = GetParentedNode(typeReference);
            _expressionList = GetParentedNode(expressionList);
            _initializerExpression = GetParentedNode(initializerExpression);
        }

        public ParseNode ExpressionList {
            get {
                return _expressionList;
            }
        }

        public ParseNode InitializerExpression {
            get {
                return _initializerExpression;
            }
        }

        public ParseNode TypeReference {
            get {
                return _typeReference;
            }
        }
    }
}
