// ConstantDeclarationNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal class ConstantDeclarationNode : VariableDeclarationNode {

        public ConstantDeclarationNode(Token token,
                                       ParseNodeList attributes,
                                       Modifiers modifiers,
                                       ParseNode type,
                                       ParseNodeList initializers)
            : base(ParseNodeType.ConstDeclaration, token, attributes, modifiers, type, initializers, false) {
        }
    }
}
