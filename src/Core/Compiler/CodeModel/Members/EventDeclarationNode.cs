// EventDeclarationNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal sealed class EventDeclarationNode : MemberNode {

        private ParseNodeList _attributes;
        private ParseNode _implementationMember;

        public EventDeclarationNode(Token token, ParseNodeList attributes, ParseNode backingMember)
            : base(ParseNodeType.EventDeclaration, token) {
            _attributes = GetParentedNodeList(AttributeNode.GetAttributeList(attributes));
            _implementationMember = GetParentedNode(backingMember);
        }

        public override ParseNodeList Attributes {
            get {
                return _attributes;
            }
        }

        public bool IsField {
            get {
                return (_implementationMember is VariableDeclarationNode);
            }
        }

        public FieldDeclarationNode Field {
            get {
                VariableDeclarationNode variableNode = _implementationMember as VariableDeclarationNode;
                if (variableNode != null) {
                    return new FieldDeclarationNode(variableNode.Token, new ParseNodeList(), variableNode.Modifiers, variableNode.Type, variableNode.Initializers, false);
                }
                return null;
            }
        }

        public override Modifiers Modifiers {
            get {
                if (_implementationMember is VariableDeclarationNode) {
                    VariableDeclarationNode variableNode = (VariableDeclarationNode)_implementationMember;
                    return variableNode.Modifiers;
                }
                else {
                    Debug.Assert(_implementationMember is PropertyDeclarationNode);

                    return ((PropertyDeclarationNode)_implementationMember).Modifiers;
                }
            }
        }

        public override string Name {
            get {
                if (_implementationMember is VariableDeclarationNode) {
                    VariableDeclarationNode variableNode = (VariableDeclarationNode)_implementationMember;

                    Debug.Assert(variableNode.Initializers.Count == 1);
                    Debug.Assert(variableNode.Initializers[0] is VariableInitializerNode);
                    VariableInitializerNode initializerNode = (VariableInitializerNode)variableNode.Initializers[0];

                    return initializerNode.Name.Name;
                }
                else {
                    Debug.Assert(_implementationMember is PropertyDeclarationNode);

                    return ((PropertyDeclarationNode)_implementationMember).Name;
                }
            }
        }

        public PropertyDeclarationNode Property {
            get {
                return _implementationMember as PropertyDeclarationNode;
            }
        }

        public override ParseNode Type {
            get {
                if (_implementationMember is VariableDeclarationNode) {
                    VariableDeclarationNode variableNode = (VariableDeclarationNode)_implementationMember;
                    return variableNode.Type;
                }
                else {
                    Debug.Assert(_implementationMember is PropertyDeclarationNode);

                    return ((PropertyDeclarationNode)_implementationMember).Type;
                }
            }
        }
    }
}
