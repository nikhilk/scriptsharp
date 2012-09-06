// ConstructorDeclarationNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal sealed class ConstructorDeclarationNode : MethodDeclarationNode {

        private bool _callBase;
        private ParseNode _baseArguments;

        public ConstructorDeclarationNode(Token token,
                                          ParseNodeList attributes,
                                          Modifiers modifiers,
                                          AtomicNameNode name,
                                          ParseNodeList formals,
                                          bool callBase,
                                          ParseNode baseArguments,
                                          BlockStatementNode body)
            : base(ParseNodeType.ConstructorDeclaration, token, attributes, modifiers, /* return type */ null, name, formals, body) {
            _callBase = callBase;
            _baseArguments = GetParentedNode(baseArguments);
        }

        public ParseNode BaseArguments {
            get {
                return _baseArguments;
            }
        }

        public bool CallBase {
            get {
                return _callBase;
            }
        }
    }
}
