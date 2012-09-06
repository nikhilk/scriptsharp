// ParseNodeList.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal sealed class ParseNodeList : IEnumerable {

        private ArrayList _list;

        public ParseNodeList() {
        }

        public ParseNodeList(ParseNode node) {
            Append(node);
        }

        public int Count {
            get {
                if (_list == null) {
                    return 0;
                }
                else {
                    return _list.Count;
                }
            }
        }

        public ParseNode this[int index] {
            get {
                return (ParseNode)_list[index];
            }
        }

        public void Append(ParseNode node) {
            if (node != null) {
                EnsureListCreated();
                _list.Add(node);
            }
        }

        public void Append(ParseNodeList nodes) {
            EnsureListCreated();
            _list.AddRange(nodes._list);
        }

        private void EnsureListCreated() {
            if (_list == null) {
                _list = new ArrayList();
            }
        }

        public ParseNodeEnumerator GetEnumerator() {
            return new ParseNodeEnumerator(this);
        }

        internal void SetParent(ParseNode parent) {
            if (_list != null) {
                _list.TrimToSize();
                foreach (ParseNode child in this) {
                    child.SetParent(parent);
                }
            }
        }

        #region Implementation of IEnumerable
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
        #endregion


        public sealed class ParseNodeEnumerator : IEnumerator {

            private ArrayList _list;
            private int _current;

            public ParseNodeEnumerator(ParseNodeList nodes) {
                _list = nodes._list;
            }

            public ParseNode Current {
                get {
                    return (ParseNode)_list[_current - 1];
                }
            }

            public bool MoveNext() {
                if ((_list != null) && (_current < _list.Count)) {
                    _current += 1;
                    return true;
                }

                return false;
            }

            #region Implementation of IEnumerator
            object IEnumerator.Current {
                get {
                    return Current;
                }
            }

            bool IEnumerator.MoveNext() {
                return MoveNext();
            }

            void IEnumerator.Reset() {
                _current = 0;
            }
            #endregion
        }
    }
}
