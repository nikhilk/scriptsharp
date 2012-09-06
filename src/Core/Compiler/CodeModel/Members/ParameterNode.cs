// ParameterNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal sealed class ParameterNode : ParseNode {

        private ParseNodeList _attributes;
        private ParameterFlags _flags;
        private ParseNode _type;
        private AtomicNameNode _name;

        public ParameterNode(Token token,
                                   ParseNodeList attributes,
                                   ParameterFlags flags,
                                   ParseNode type,
                                   AtomicNameNode name)
            : base(ParseNodeType.FormalParameter, token) {
            _attributes = GetParentedNodeList(AttributeNode.GetAttributeList(attributes));
            _flags = flags;
            _type = GetParentedNode(type);
            _name = (AtomicNameNode)GetParentedNode(name);
        }

        public ParseNodeList Attributes {
            get {
                return _attributes;
            }
        }

        public ParameterFlags Flags {
            get {
                return _flags;
            }
        }

        public string Name {
            get {
                return _name.Name;
            }
        }

        public ParseNode Type {
            get {
                return _type;
            }
        }
    }
}
