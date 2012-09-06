// AttributeNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal sealed class AttributeNode : ParseNode {

        private NameNode _typeName;
        private ParseNode _arguments;

        public AttributeNode(NameNode typeName, ParseNode arguments)
            : base(ParseNodeType.Attribute, typeName.token) {
            _typeName = (NameNode)GetParentedNode(typeName);
            _arguments = GetParentedNode(arguments);
        }

        public ParseNodeList Arguments {
            get {
                if (_arguments != null) {
                    return ((ExpressionListNode)_arguments).Expressions;
                }
                return null;
            }
        }

        public string TypeName {
            get {
                return _typeName.Name;
            }
        }

        public static AttributeNode FindAttribute(ParseNodeList attributeNodes, string attributeName) {
            if ((attributeNodes == null) || (attributeNodes.Count == 0)) {
                return null;
            }

            foreach (AttributeNode attrNode in attributeNodes) {
                if (attrNode.TypeName.Equals(attributeName, StringComparison.Ordinal)) {
                    return attrNode;
                }
            }

            return null;
        }

        public static ParseNodeList GetAttributeList(ParseNodeList attributeBlocks) {
            if ((attributeBlocks == null)  || (attributeBlocks.Count == 0)) {
                return attributeBlocks;
            }

            ParseNodeList attributes = new ParseNodeList();
            foreach (AttributeBlockNode attributeBlock in attributeBlocks) {
                ParseNodeList localAttributes = attributeBlock.Attributes;
                if (localAttributes.Count != 0) {
                    attributes.Append(localAttributes);
                }
            }

            return attributes;
        }
    }
}
