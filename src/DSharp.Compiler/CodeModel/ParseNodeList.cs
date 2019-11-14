// ParseNodeList.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;

namespace DSharp.Compiler.CodeModel
{
    internal sealed class ParseNodeList : ParseNodeList<ParseNode>
    {
        public ParseNodeList(params ParseNode[] nodes) 
            : base(nodes)
        {
        }
    }

    internal class ParseNodeList<T> : IEnumerable<T>
        where T : ParseNode
    {
        private readonly List<T> parseNodes = new List<T>();

        public ParseNodeList(params T[] nodes)
        {
            parseNodes.AddRange(nodes);
        }

        public int Count => parseNodes.Count;

        public T this[int index] => parseNodes[index];

        public void Append(T node)
        {
            if (node != null)
            {
                parseNodes.Add(node);
            }
        }

        public void Append(ParseNodeList<T> nodes)
        {
            parseNodes.AddRange(nodes.parseNodes);
        }

        internal void SetParent(T parent)
        {
            if (parseNodes != null)
            {
                foreach (T child in this)
                    child.SetParent(parent);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return parseNodes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return parseNodes.GetEnumerator();
        }
    }
}
