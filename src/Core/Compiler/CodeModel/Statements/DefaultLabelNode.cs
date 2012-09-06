// DefaultLabelNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal sealed class DefaultLabelNode : StatementNode {

        public DefaultLabelNode(Token token)
            : base(ParseNodeType.DefaultLabel, token) {
        }
    }
}
