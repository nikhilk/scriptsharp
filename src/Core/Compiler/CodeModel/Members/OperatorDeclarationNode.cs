// OperatorDeclarationNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    // NOTE: Not supported in conversion
    internal sealed class OperatorDeclarationNode : MethodDeclarationNode {

        public TokenType operatorTokenType;

        public OperatorDeclarationNode(Token token,
                                       ParseNodeList attributes,
                                       Modifiers modifiers,
                                       TokenType operatorNodeType,
                                       ParseNode returnType,
                                       ParseNodeList formals,
                                       BlockStatementNode body)
            : base(ParseNodeType.OperatorDeclaration, token, attributes, modifiers, returnType, /* name */ null, formals, body) {
            this.operatorTokenType = operatorNodeType;
        }
    }
}
