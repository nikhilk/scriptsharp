// ExpressionNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal abstract class ExpressionNode : ParseNode {

        private bool _parenthesized;

        protected ExpressionNode(ParseNodeType nodeType, Token token)
            : base(nodeType, token) {
        }

        public bool Parenthesized {
            get {
                return _parenthesized;
            }
        }

        public void AddParenthesisHint() {
            _parenthesized = true;
        }
    }
}
