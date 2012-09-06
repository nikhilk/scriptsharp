// StatementNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal abstract class StatementNode : ParseNode {

        protected StatementNode(ParseNodeType nodeType, Token token)
            : base(nodeType, token) {
        }
    }
}
