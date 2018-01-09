// TypeParameterNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    // NOTE: Ignored in conversion
    internal sealed class TypeParameterNode : ParseNode {

        private ParseNodeList _attributes;
        private AtomicNameNode _name;

        public TypeParameterNode(ParseNodeList attributes, AtomicNameNode name)
            : base(ParseNodeType.TypeParameter, name.token) {
            _attributes = attributes;
            _name = name;
        }

        internal AtomicNameNode NameNode
        {
            get
            {
                return _name;
            }
        }
    }
}
