// ThrowNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal sealed class ThrowNode : StatementNode {

        private ParseNode _value;

        public ThrowNode(Token token, ParseNode value)
            : base(ParseNodeType.Throw, token) {
            _value = GetParentedNode(value);
        }

        public ParseNode Value {
            get {
                return _value;
            }
        }
    }
}
