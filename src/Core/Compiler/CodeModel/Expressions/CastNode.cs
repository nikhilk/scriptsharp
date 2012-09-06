// CastNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal sealed class CastNode : ExpressionNode {

        private ParseNode _typeReference;
        private ParseNode _child;

        public CastNode(Token token, ParseNode typeReference, ParseNode child)
            : base(ParseNodeType.Cast, token) {
            _typeReference = GetParentedNode(typeReference);
            _child = GetParentedNode(child);
        }

        public ParseNode Child {
            get {
                return _child;
            }
        }

        public ParseNode TypeReference {
            get {
                return _typeReference;
            }
        }
    }
}
