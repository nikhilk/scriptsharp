// DoWhileNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal sealed class DoWhileNode : StatementNode {

        private ParseNode _condition;
        private ParseNode _body;

        public DoWhileNode(Token token,
                      ParseNode body,
                      ParseNode condition)
            : base(ParseNodeType.DoWhile, token) {
            _body = GetParentedNode(body);
            _condition = GetParentedNode(condition);
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
