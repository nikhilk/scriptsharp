// ArrayList.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Collections {

    // NOTE: Keep in sync with ArrayGrouping and Array

    /// <summary>
    /// Equivalent to the Array type in Javascript.
    /// </summary>
    [IgnoreNamespace]
    [Imported]
    [ScriptName("Array")]
    public sealed class ArrayList : IEnumerable {

        public ArrayList() {
        }

        public ArrayList(int capacity) {
        }

        public ArrayList(params object[] items) {
        }

        [IntrinsicProperty]
        [ScriptName("length")]
        public int Count {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public object this[int index] {
            get {
                return null;
            }
            set {
            }
        }

        public void Add(object item) {
        }

        public void AddRange(object[] items) {
        }

        public object Aggregate(object seedValue, ArrayAggregator aggregator) {
            return null;
        }

        public object Aggregate(object seedValue, ArrayItemAggregator aggregator) {
            return null;
        }

        public ArrayList Clone() {
            return null;
        }

        public void Clear() {
        }

        public ArrayList Concat(params object[] objects) {
            return null;
        }

        public bool Contains(object item) {
            return false;
        }

        public bool Every(ArrayFilterCallback filterCallback) {
            return false;
        }

        public bool Every(ArrayItemFilterCallback itemFilterCallback) {
            return false;
        }

        public Array Extract(int index) {
            return null;
        }

        public Array Extract(int index, int count) {
            return null;
        }

        public Array Filter(ArrayFilterCallback filterCallback) {
            return null;
        }

        public Array Filter(ArrayItemFilterCallback itemFilterCallback) {
            return null;
        }

        public void ForEach(ArrayCallback callback) {
        }

        public void ForEach(ArrayItemCallback itemCallback) {
        }

        public IEnumerator GetEnumerator() {
            return null;
        }

        public ArrayGrouping[] GroupBy(ArrayItemKeyGenerator keyCallback) {
            return null;
        }

        public Dictionary Index(ArrayItemKeyGenerator keyCallback) {
            return null;
        }

        public int IndexOf(object item) {
            return 0;
        }

        public int IndexOf(object item, int startIndex) {
            return 0;
        }

        public void Insert(int index, object item) {
        }

        public void InsertRange(int index, object[] items) {
        }

        public string Join() {
            return null;
        }

        public string Join(string delimiter) {
            return null;
        }

        public Array Map(ArrayMapCallback mapCallback) {
            return null;
        }

        public Array Map(ArrayItemMapCallback mapItemCallback) {
            return null;
        }

        public static ArrayList Parse(string s) {
            return null;
        }

        public bool Remove(object item) {
            return false;
        }

        public void RemoveAt(int index) {
        }

        public Array RemoveRange(int index, int count) {
            return null;
        }

        public void Reverse() {
        }

        public bool Some(ArrayFilterCallback filterCallback) {
            return false;
        }

        public bool Some(ArrayItemFilterCallback itemFilterCallback) {
            return false;
        }

        public void Sort() {
        }

        public void Sort(CompareCallback compareCallback) {
        }

        public static explicit operator Array(ArrayList list) {
            return null;
        }
    }
}
