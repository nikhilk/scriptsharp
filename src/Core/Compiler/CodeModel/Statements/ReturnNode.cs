// ReturnNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal class ReturnNode : StatementNode {

        private ParseNode _value;

        public ReturnNode(Token token, ParseNode value)
            : base(ParseNodeType.Return, token) {
            _value = GetParentedNode(value);
        }

        public ParseNode Value {
            get {
                return _value;
            }
        }
    }
}
