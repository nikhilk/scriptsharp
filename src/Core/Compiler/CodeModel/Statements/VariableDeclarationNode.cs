// VariableDeclarationNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal class VariableDeclarationNode : StatementNode {

        private ParseNodeList attributes;
        private Modifiers modifiers;
        private ParseNode type;
        private ParseNodeList initializers;
        private bool isFixed;

        public VariableDeclarationNode(Token token,
                                       ParseNodeList attributes,
                                       Modifiers modifiers,
                                       ParseNode type,
                                       ParseNodeList initializers,
                                       bool isFixed)
            : this(ParseNodeType.VariableDeclaration, token, attributes, modifiers, type, initializers, isFixed) {
        }

        protected VariableDeclarationNode(ParseNodeType nodeType, Token token,
                                          ParseNodeList attributes,
                                          Modifiers modifiers,
                                          ParseNode type,
                                          ParseNodeList initializers,
                                          bool isFixed)
            : base(nodeType, token) {
            this.attributes = GetParentedNodeList(attributes);
            this.modifiers = modifiers;
            this.type = GetParentedNode(type);
            this.initializers = GetParentedNodeList(initializers);
            this.isFixed = isFixed;
        }

        public ParseNodeList Initializers {
            get {
                return initializers;
            }
        }

        public bool IsFixed {
            get {
                return isFixed;
            }
        }

        public Modifiers Modifiers {
            get {
                return modifiers;
            }
        }

        public ParseNode Type {
            get {
                return type;
            }
        }
    }
}
