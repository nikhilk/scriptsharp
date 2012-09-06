// FieldDeclarationNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal class FieldDeclarationNode : MemberNode {

        private ParseNodeList _attributes;
        private Modifiers _modifiers;
        private ParseNode _type;
        private ParseNodeList _initializers;
        private bool _isFixed;

        public FieldDeclarationNode(Token token,
                                    ParseNodeList attributes,
                                    Modifiers modifiers,
                                    ParseNode type,
                                    ParseNodeList initializers,
                                    bool isFixed)
            : this(ParseNodeType.FieldDeclaration, token, attributes, modifiers, type, initializers, isFixed) {
        }

        protected FieldDeclarationNode(ParseNodeType nodeType, Token token,
                                       ParseNodeList attributes,
                                       Modifiers modifiers,
                                       ParseNode type,
                                       ParseNodeList initializers,
                                       bool isFixed)
            : base(nodeType, token) {
            _attributes = GetParentedNodeList(AttributeNode.GetAttributeList(attributes));
            _modifiers = modifiers;
            _type = GetParentedNode(type);
            _initializers = GetParentedNodeList(initializers);
            _isFixed = isFixed;
        }

        public override ParseNodeList Attributes {
            get {
                return _attributes;
            }
        }

        public ParseNodeList Initializers {
            get {
                return _initializers;
            }
        }

        public bool IsFixed {
            get {
                return _isFixed;
            }
        }

        public override Modifiers Modifiers {
            get {
                return _modifiers;
            }
        }

        public override string Name {
            get {
                Debug.Assert(_initializers.Count == 1);
                Debug.Assert(_initializers[0] is VariableInitializerNode);

                VariableInitializerNode variableNode = (VariableInitializerNode)_initializers[0];
                return variableNode.Name.Name;
            }
        }

        public override ParseNode Type {
            get {
                return _type;
            }
        }
    }
}
