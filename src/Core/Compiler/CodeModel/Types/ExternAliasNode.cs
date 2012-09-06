// ExternAliasNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    // NOTE: This is supported in conversion
    internal sealed class ExternAliasNode : ParseNode {

        private NameNode _aliasName;

        public ExternAliasNode(Token token, AtomicNameNode aliasName)
            : base(ParseNodeType.ExternAlias, token) {
            _aliasName = (AtomicNameNode)GetParentedNode(aliasName);
        }
    }
}
