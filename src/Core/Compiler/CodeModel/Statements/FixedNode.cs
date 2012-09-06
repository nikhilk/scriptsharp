// FixedNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    // NOTE: Not supported in conversion
    internal sealed class FixedNode : StatementNode {

        private VariableDeclarationNode _declaration;
        private ParseNode _body;

        public FixedNode(Token token,
                         VariableDeclarationNode declaration,
                         ParseNode body)
            : base(ParseNodeType.Fixed, token) {
            _declaration = (VariableDeclarationNode)GetParentedNode(declaration);
            _body = GetParentedNode(body);
        }
    }
}
