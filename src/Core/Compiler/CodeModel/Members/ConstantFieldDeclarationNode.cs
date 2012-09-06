// ConstantFieldDeclarationNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal class ConstantFieldDeclarationNode : FieldDeclarationNode {

        public ConstantFieldDeclarationNode(Token token,
                                            ParseNodeList attributes,
                                            Modifiers modifiers,
                                            ParseNode type,
                                            ParseNodeList initializers)
            : base(ParseNodeType.ConstFieldDeclaration, token, attributes, modifiers, type, initializers, false) {
        }
    }
}
