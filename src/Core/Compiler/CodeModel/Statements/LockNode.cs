// LockNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    // NOTE: Not supported in conversion
    internal sealed class LockNode : StatementNode {

        public ParseNode monitor;
        public ParseNode body;

        public LockNode(Token token,
                        ParseNode monitor,
                        ParseNode body)
            : base(ParseNodeType.Lock, token) {
            this.monitor = GetParentedNode(monitor);
            this.body = GetParentedNode(body);
        }
    }
}
