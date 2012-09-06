// DelegateTypeNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    // NOTE: Ignored in conversion
    internal sealed class DelegateTypeNode : UserTypeNode {

        private ParseNode _returnType;
        private ParseNodeList _parameters;

        public DelegateTypeNode(Token token,
                                ParseNodeList attributes,
                                Modifiers modifiers,
                                ParseNode returnType,
                                AtomicNameNode name,
                                ParseNodeList typeParameters,
                                ParseNodeList parameters,
                                ParseNodeList constraintClauses)
            : base(ParseNodeType.Delegate, token, TokenType.Delegate, attributes, modifiers, name, typeParameters, constraintClauses) {
            _returnType = GetParentedNode(returnType);
            _parameters = GetParentedNodeList(parameters);
        }

        public ParseNodeList Parameters {
            get {
                return _parameters;
            }
        }

        public ParseNode ReturnType {
            get {
                return _returnType;
            }
        }
    }
}
