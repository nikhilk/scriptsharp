// BlockStatementNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal sealed class BlockStatementNode : StatementNode {

        private ParseNodeList _statements;

        public BlockStatementNode(Token token, ParseNodeList statements)
            : base(ParseNodeType.Block, token) {
            _statements = GetParentedNodeList(statements);
        }

        public ParseNodeList Statements {
            get {
                return _statements;
            }
        }
    }
}
