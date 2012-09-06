// PropertyDeclarationNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal class PropertyDeclarationNode : MemberNode {

        private ParseNodeList _attributes;
        private Modifiers _modifiers;
        private ParseNode _type;
        private NameNode _interfaceType;
        private NameNode _name;
        private AccessorNode _getOrRemove;
        private AccessorNode _setOrAdd;

        public PropertyDeclarationNode(Token token,
                                       ParseNodeList attributes,
                                       Modifiers modifiers,
                                       ParseNode type,
                                       NameNode interfaceType,
                                       AtomicNameNode name,
                                       AccessorNode getOrRemove,
                                       AccessorNode setOrAdd)
            : this(ParseNodeType.PropertyDeclaration, token, attributes, modifiers, type, interfaceType, getOrRemove, setOrAdd) {
            _name = (AtomicNameNode)GetParentedNode(name);
        }

        protected PropertyDeclarationNode(ParseNodeType nodeType, Token token,
                                          ParseNodeList attributes,
                                          Modifiers modifiers,
                                          ParseNode type,
                                          NameNode interfaceType,
                                          AccessorNode getOrRemove,
                                          AccessorNode setOrAdd)
            : base(nodeType, token) {
            _attributes = GetParentedNodeList(AttributeNode.GetAttributeList(attributes));
            _modifiers = modifiers;
            _type = GetParentedNode(type);
            _interfaceType = (NameNode)GetParentedNode(interfaceType);
            _getOrRemove = (AccessorNode)GetParentedNode(getOrRemove);
            _setOrAdd = (AccessorNode)GetParentedNode(setOrAdd);
        }

        public override ParseNodeList Attributes {
            get {
                return _attributes;
            }
        }

        public AccessorNode GetAccessor {
            get {
                return _getOrRemove;
            }
        }

        public ParseNode InterfaceType {
            get {
                return _interfaceType;
            }
        }

        public override Modifiers Modifiers {
            get {
                return _modifiers;
            }
        }

        public override string Name {
            get {
                Debug.Assert(_name != null);
                return _name.Name;
            }
        }

        public NameNode NameNode {
            get {
                return _name;
            }
        }

        public AccessorNode SetAccessor {
            get {
                return _setOrAdd;
            }
        }

        public override ParseNode Type {
            get {
                return _type;
            }
        }
    }
}
