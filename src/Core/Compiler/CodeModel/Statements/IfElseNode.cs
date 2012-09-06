// IfElseNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal sealed class IfElseNode : StatementNode {

        private ParseNode _condition;
        private ParseNode _ifBlock;
        private ParseNode _elseBlock;

        public IfElseNode(Token token,
                      ParseNode condition,
                      ParseNode ifBlock,
                      ParseNode elseBlock)
            : base(ParseNodeType.IfElse, token) {
            _condition = GetParentedNode(condition);
            _ifBlock = GetParentedNode(ifBlock);
            _elseBlock = GetParentedNode(elseBlock);
        }

        public ParseNode Condition {
            get {
                return _condition;
            }
        }

        public ParseNode ElseBlock {
            get {
                return _elseBlock;
            }
        }

        public ParseNode IfBlock {
            get {
                return _ifBlock;
            }
        }
    }
}
