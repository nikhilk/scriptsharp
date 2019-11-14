// ParseNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel
{
    /// <summary>
    ///     The root of the parse tree hierarchy.
    ///     Note that any ParseNode can be treated as a ListTree.
    ///     A null value corresponds to an empty list. A non-ListTree
    ///     ParseNode is a list of 1 element. While a ListTree is used
    ///     for lists containing more than 1 element.
    /// </summary>
    internal abstract class ParseNode
    {
        protected ParseNode(ParseNodeType nodeType, Token token)
        {
            this.NodeType = nodeType;
            this.Token = token;
        }

        public ParseNodeType NodeType { get; }

        public ParseNode Parent { get; private set; }

        public Token Token { get; }

        protected ParseNode GetParentedNode(ParseNode child)
        {
            child?.SetParent(this);

            return child;
        }

        protected ParseNodeList GetParentedNodeList(ParseNodeList nodeList)
        {
            nodeList.SetParent(this);

            return nodeList;
        }

        internal void SetParent(ParseNode node)
        {
            Parent = node;
        }
    }
}
