// ExpressionNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    // NOTE: Not supported in conversion
    internal class SizeofNode : ExpressionNode {

        private ParseNode _typeNode;

        public SizeofNode(Token op, ParseNode typeNode)
            : base(ParseNodeType.Sizeof, op) {
            _typeNode = GetParentedNode(typeNode);
        }
    }
}
