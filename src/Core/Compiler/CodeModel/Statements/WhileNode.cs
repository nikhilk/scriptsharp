// WhileNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal sealed class WhileNode : StatementNode {

        private ParseNode _condition;
        private ParseNode _body;

        public WhileNode(Token token,
                         ParseNode condition,
                         ParseNode body)
            : base(ParseNodeType.While, token) {
            _condition = GetParentedNode(condition);
            _body = GetParentedNode(body);
        }

        public ParseNode Body {
            get {
                return _body;
            }
        }

        public ParseNode Condition {
            get {
                return _condition;
            }
        }
    }
}
