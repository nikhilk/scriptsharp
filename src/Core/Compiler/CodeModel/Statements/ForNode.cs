// ForNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal sealed class ForNode : StatementNode {

        private ParseNode _initializer;
        private ParseNode _condition;
        private ParseNode _increment;
        private ParseNode _body;

        public ForNode(Token token,
                       ParseNode initializer,
                       ParseNode condition,
                       ParseNode increment,
                       ParseNode body)
            : base(ParseNodeType.For, token) {
            _initializer = GetParentedNode(initializer);
            _condition = GetParentedNode(condition);
            _increment = GetParentedNode(increment);
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

        public ParseNode Increment {
            get {
                return _increment;
            }
        }

        public ParseNode Initializer {
            get {
                return _initializer;
            }
        }
    }
}
