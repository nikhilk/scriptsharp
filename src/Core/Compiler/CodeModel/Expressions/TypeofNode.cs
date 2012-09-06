// TypeofNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal sealed class TypeofNode : ExpressionNode {

        private ParseNode _typeReference;

        public TypeofNode(Token op, ParseNode typeReference)
            : base(ParseNodeType.Typeof, op) {
            _typeReference = GetParentedNode(typeReference);
        }

        public ParseNode TypeReference {
            get {
                return _typeReference;
            }
        }
    }
}
