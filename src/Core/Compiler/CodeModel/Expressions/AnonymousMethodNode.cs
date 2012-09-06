// AnonymousMethodNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    // NOTE: Not supported in conversion
    internal sealed class AnonymousMethodNode : ExpressionNode {

        private ParseNodeList _parameterList;
        private BlockStatementNode _block;

        public AnonymousMethodNode(Token token, ParseNodeList parameterList, BlockStatementNode block)
            : base(ParseNodeType.AnonymousMethod, token) {
            _parameterList = GetParentedNodeList(parameterList);
            _block = (BlockStatementNode)GetParentedNode(block);
        }

        public BlockStatementNode Implementation {
            get {
                return _block;
            }
        }

        public ParseNodeList Parameters {
            get {
                return _parameterList;
            }
        }
    }
}
