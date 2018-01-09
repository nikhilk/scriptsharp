// MethodDeclarationNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal class MethodDeclarationNode : MemberNode {

        private ParseNodeList _attributes;
        private Modifiers _modifiers;
        private ParseNode _returnType;
        private NameNode _interfaceType;
        private AtomicNameNode _name;
        private ParseNodeList _typeParameters;
        private ParseNodeList _parameters;
        private ParseNodeList _constraints;
        private BlockStatementNode _implementation;

        public MethodDeclarationNode(Token token,
                                     ParseNodeList attributes,
                                     Modifiers modifiers,
                                     ParseNode returnType,
                                     NameNode interfaceType,
                                     AtomicNameNode name,
                                     ParseNodeList typeParameters,
                                     ParseNodeList formals,
                                     ParseNodeList constraints,
                                     BlockStatementNode body)
            : this(ParseNodeType.MethodDeclaration, token, attributes, modifiers, returnType, name, formals, body) {
            _interfaceType = (NameNode)GetParentedNode(interfaceType);
            _typeParameters = GetParentedNodeList(typeParameters);
            _constraints = GetParentedNodeList(constraints);
        }

        protected MethodDeclarationNode(ParseNodeType nodeType, Token token,
                                        ParseNodeList attributes,
                                        Modifiers modifiers,
                                        ParseNode returnType,
                                        AtomicNameNode name,
                                        ParseNodeList formals,
                                        BlockStatementNode body)
            : base(nodeType, token) {
            _attributes = GetParentedNodeList(AttributeNode.GetAttributeList(attributes));
            _modifiers = modifiers;
            _returnType = GetParentedNode(returnType);
            _name = (AtomicNameNode)GetParentedNode(name);
            _parameters = GetParentedNodeList(formals);
            _implementation = (BlockStatementNode)GetParentedNode(body);
        }

        public override ParseNodeList Attributes {
            get {
                return _attributes;
            }
        }

        public BlockStatementNode Implementation {
            get {
                return _implementation;
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
                return _name.Name;
            }
        }

        public ParseNodeList Parameters {
            get {
                return _parameters;
            }
        }

        public override ParseNode Type {
            get {
                return _returnType;
            }
        }

        public ParseNodeList TypeParameters
        {
            get
            {
                return _typeParameters;
            }
        }
    }
}
