// StackAllocNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    // NOTE: Not supported in conversion
    internal sealed class StackAllocNode : ExpressionNode {

        private ParseNode _type;
        private ParseNode _numberOfElements;

        public StackAllocNode(Token token, ParseNode type, ParseNode numberOfElements)
            : base(ParseNodeType.StackAlloc, token) {
            _type = GetParentedNode(type);
            _numberOfElements = GetParentedNode(numberOfElements);
        }
    }
}
