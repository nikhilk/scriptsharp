// UncheckedNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    // NOTE: Not supported in conversion
    internal sealed class UncheckedNode : StatementNode {

        private BlockStatementNode _body;

        public UncheckedNode(Token token, BlockStatementNode body)
            : base(ParseNodeType.Unchecked, token) {
            _body = (BlockStatementNode)GetParentedNode(body);
        }
    }
}
