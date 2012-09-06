// GotoNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    // NOTE: Not supported in conversion
    internal sealed class GotoNode : StatementNode {

        private ParseNode _value;

        public GotoNode(Token token, ParseNode value)
            : base(ParseNodeType.Goto, token) {
            _value = GetParentedNode(value);
        }
    }
}
