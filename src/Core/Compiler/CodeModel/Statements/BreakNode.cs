// BreakNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal sealed class BreakNode : StatementNode {

        public BreakNode(Token token)
            : base(ParseNodeType.Break, token) {
        }
    }
}
