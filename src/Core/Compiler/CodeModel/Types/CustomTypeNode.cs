// CustomTypeNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal sealed class CustomTypeNode : UserTypeNode {

        private ParseNodeList _baseTypes;
        private ParseNodeList _members;

        public CustomTypeNode(Token token, TokenType type,
                              ParseNodeList attributes,
                              Modifiers modifiers,
                              AtomicNameNode name,
                              ParseNodeList typeParameters,
                              ParseNodeList baseTypes,
                              ParseNodeList constraintClauses,
                              ParseNodeList members)
            : base(ParseNodeType.Type, token, type, attributes, modifiers, name, typeParameters, constraintClauses) {
            _baseTypes = GetParentedNodeList(baseTypes);
            _members = GetParentedNodeList(members);
        }

        public ParseNodeList BaseTypes {
            get {
                return _baseTypes;
            }
        }

        public ParseNodeList Members {
            get {
                return _members;
            }
        }

        internal override void MergePartialType(CustomTypeNode partialTypeNode) {
            base.MergePartialType(partialTypeNode);

            if (partialTypeNode._baseTypes.Count > 0) {
                _baseTypes.Append(GetParentedNodeList(partialTypeNode._baseTypes));
            }
        }
    }
}
