// AttributeBlockNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal sealed class AttributeBlockNode : ParseNode {

        private AttributeTargets _location;
        private ParseNodeList _attributes;

        public AttributeBlockNode(Token token,
                                  AttributeTargets location,
                                  ParseNodeList attributes)
            : base(ParseNodeType.AttributeBlock, token) {
            _location = location;
            _attributes = GetParentedNodeList(attributes);
        }

        public ParseNodeList Attributes {
            get {
                return _attributes;
            }
        }
    }
}
