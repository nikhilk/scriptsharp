// DestructorDeclarationNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    // NOTE: Not supported in conversion
    internal sealed class DestructorDeclarationNode : MethodDeclarationNode {

        public DestructorDeclarationNode(Token token,
                                         ParseNodeList attributes,
                                         Modifiers modifiers,
                                         AtomicNameNode name,
                                         BlockStatementNode body)
            : base(ParseNodeType.DestructorDeclaration, token, attributes, modifiers, /* return type */ null, name, new ParseNodeList(), body) {
        }
    }
}
