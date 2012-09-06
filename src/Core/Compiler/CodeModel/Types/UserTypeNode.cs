// UserTypeNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal abstract class UserTypeNode : TypeNode {

        private TokenType _type;
        private ParseNodeList _attributes;
        private Modifiers _modifiers;
        private AtomicNameNode _nameNode;
        private ParseNodeList _typeParameters;
        private ParseNodeList _constraintClauses;

        public UserTypeNode(ParseNodeType type, Token token, TokenType tokenType,
                            ParseNodeList attributes,
                            Modifiers modifiers,
                            AtomicNameNode name,
                            ParseNodeList typeParameters,
                            ParseNodeList constraintClauses)
            : base(type, token) {
            _type = tokenType;
            _attributes = GetParentedNodeList(AttributeNode.GetAttributeList(attributes));
            _modifiers = modifiers;
            _nameNode = name;
            _typeParameters = GetParentedNodeList(typeParameters);
            _constraintClauses = GetParentedNodeList(constraintClauses);
        }

        public ParseNodeList Attributes {
            get {
                return _attributes;
            }
        }

        public string Name {
            get {
                return _nameNode.Name;
            }
        }

        public NameNode NameNode {
            get {
                return _nameNode;
            }
        }

        public Modifiers Modifiers {
            get {
                return _modifiers;
            }
        }

        public TokenType Type {
            get {
                return _type;
            }
        }

        internal virtual void MergePartialType(CustomTypeNode partialTypeNode) {
            Debug.Assert(Name == partialTypeNode.Name);

            if (partialTypeNode._attributes.Count > 0) {
                _attributes.Append(GetParentedNodeList(partialTypeNode._attributes));
            }

            if ((partialTypeNode.Modifiers & Modifiers.PartialModifiers) != 0) {
                _modifiers |= (partialTypeNode.Modifiers & Modifiers.PartialModifiers);
            }

            if (partialTypeNode._typeParameters.Count > 0) {
                _typeParameters.Append(GetParentedNodeList(partialTypeNode._typeParameters));
            }

            if (partialTypeNode._constraintClauses.Count > 0) {
                _constraintClauses.Append(GetParentedNodeList(partialTypeNode._constraintClauses));
            }
        }
    }
}
