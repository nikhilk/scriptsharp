// UnsafeNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    // NOTE: Not supported in conversion
    internal class UnsafeNode : StatementNode {

        private ParseNode _body;

        public UnsafeNode(Token token, ParseNode body)
            : base(ParseNodeType.UnsafeStatement, token) {
            _body = body;
        }
    }
}
