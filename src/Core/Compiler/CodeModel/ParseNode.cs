// ParseNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    /// <summary>
    /// The root of the parse tree hierarchy.
    /// Note that any ParseNode can be treated as a ListTree.
    /// A null value corresponds to an empty list. A non-ListTree
    /// ParseNode is a list of 1 element. While a ListTree is used
    /// for lists containing more than 1 element.
    /// </summary>
    internal abstract class ParseNode {

        public ParseNodeType nodeType;
        public Token token;
        public ParseNode parent;

        protected ParseNode(ParseNodeType nodeType, Token token) {
            this.nodeType = nodeType;
            this.token = token;
        }

        public ParseNodeType NodeType {
            get {
                return nodeType;
            }
        }

        public ParseNode Parent {
            get {
                return parent;
            }
        }

        public Token Token {
            get {
                return token;
            }
        }

        protected ParseNode GetParentedNode(ParseNode child) {
            if (child != null) {
                child.SetParent(this);
            }
            return child;
        }

        protected ParseNodeList GetParentedNodeList(ParseNodeList nodeList) {
            nodeList.SetParent(this);
            return nodeList;
        }

        internal void SetParent(ParseNode node) {
            parent = node;
        }
    }
}
