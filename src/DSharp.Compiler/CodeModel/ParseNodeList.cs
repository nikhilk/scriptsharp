// ParseNodeList.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections;
using System.Collections.Generic;

namespace DSharp.Compiler.CodeModel
{
    internal sealed class ParseNodeList : IEnumerable<ParseNode>
    {
        private readonly List<ParseNode> parseNodes = new List<ParseNode>();

        public ParseNodeList(params ParseNode[] nodes)
        {
            parseNodes.AddRange(nodes);
        }

        public int Count => parseNodes.Count;

        public ParseNode this[int index] => parseNodes[index];

        public void Append(ParseNode node)
        {
            if (node != null)
            {
                parseNodes.Add(node);
            }
        }

        public void Append(ParseNodeList nodes)
        {
            parseNodes.AddRange(nodes.parseNodes);
        }

        internal void SetParent(ParseNode parent)
        {
            if (parseNodes != null)
            {
                foreach (ParseNode child in this)
                    child.SetParent(parent);
            }
        }

        public IEnumerator<ParseNode> GetEnumerator()
        {
            return parseNodes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return parseNodes.GetEnumerator();
        }
    }
}
