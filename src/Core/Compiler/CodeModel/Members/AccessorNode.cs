// AccessorNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal sealed class AccessorNode : ParseNode {

        private AtomicNameNode _name;
        private BlockStatementNode _implementation;
        private ParseNodeList _attributes;
        private Modifiers _modifiers;

        public AccessorNode(Token token,
                            ParseNodeList attributes,
                            AtomicNameNode name,
                            BlockStatementNode body,
                            Modifiers modifiers)
            : base(ParseNodeType.AccessorDeclaration, token) {
            _name = (AtomicNameNode)GetParentedNode(name);
            _implementation = (BlockStatementNode)GetParentedNode(body);
            _attributes = GetParentedNodeList(attributes);
            _modifiers = modifiers;
        }

        public BlockStatementNode Implementation {
            get {
                return _implementation;
            }
        }

        public Modifiers Modifiers {
            get {
                return _modifiers;
            }
        }

        public AccessorType Type {
            get {
                if (_name.Name.Equals("get")) {
                    return AccessorType.Get;
                }
                return AccessorType.Set;
            }
        }
    }
}
