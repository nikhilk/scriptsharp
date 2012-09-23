// ObservableCollection.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Collections {

    [ScriptImport]
    [ScriptName("ObservableCollection")]
    public sealed class ObservableCollection : IEnumerable {

        public ObservableCollection() {
        }

        public ObservableCollection(Array items) {
        }

        [ScriptName("length")]
        public int Count {
            get {
                return 0;
            }
        }

        public object this[int index] {
            get {
                return null;
            }
            set {
            }
        }

        public void Add(object item) {
        }

        public void Clear() {
        }

        public bool Contains(object item) {
            return false;
        }

        public IEnumerator GetEnumerator() {
            return null;
        }

        public int IndexOf(object item) {
            return 0;
        }

        public void Insert(int index, object item) {
        }

        public bool Remove(object item) {
            return false;
        }

        public void RemoveAt(int index) {
        }

        public Array ToArray() {
            return null;
        }
    }
}
