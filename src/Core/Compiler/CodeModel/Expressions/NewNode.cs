// NewNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal sealed class NewNode : ExpressionNode {

        private ParseNode _typeReference;
        private ParseNode _arguments;

        public NewNode(Token token, ParseNode typeReference, ParseNode arguments)
            : base(ParseNodeType.New, token) {
            _typeReference = GetParentedNode(typeReference);
            _arguments = GetParentedNode(arguments);
        }

        public ParseNode Arguments {
            get {
                return _arguments;
            }
        }

        public ParseNode TypeReference {
            get {
                return _typeReference;
            }
            set {
                _typeReference = value;
            }
        }
    }
}
