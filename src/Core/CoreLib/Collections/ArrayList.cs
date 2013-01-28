// ArrayList.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Collections {

    // NOTE: Keep in sync with Array and List

    /// <summary>
    /// Equivalent to the Array type in Javascript.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("Array")]
    public sealed class ArrayList : IEnumerable {

        public ArrayList() {
        }

        public ArrayList(int capacity) {
        }

        public ArrayList(params object[] items) {
        }

        [ScriptField]
        [ScriptName("length")]
        public int Count {
            get {
                return 0;
            }
        }

        [ScriptField]
        public object this[int index] {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptName("push")]
        public void Add(object item) {
        }

        [ScriptName("push")]
        public void AddRange(params object[] items) {
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

        public Array GetRange(int index) {
            return null;
        }

        public Array GetRange(int index, int count) {
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

        public void InsertRange(int index, params object[] items) {
        }

        public string Join() {
            return null;
        }

        public string Join(string delimiter) {
            return null;
        }

        public int LastIndexOf(object item) {
            return 0;
        }

        public int LastIndexOf(object item, int fromIndex) {
            return 0;
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

        public object Reduce(ArrayReduceCallback callback) {
            return null;
        }

        public object Reduce(ArrayReduceCallback callback, object initialValue) {
            return null;
        }

        public object Reduce(ArrayItemReduceCallback callback) {
            return null;
        }

        public object Reduce(ArrayItemReduceCallback callback, object initialValue) {
            return null;
        }

        public object ReduceRight(ArrayReduceCallback callback) {
            return null;
        }

        public object ReduceRight(ArrayReduceCallback callback, object initialValue) {
            return null;
        }

        public object ReduceRight(ArrayItemReduceCallback callback) {
            return null;
        }

        public object ReduceRight(ArrayItemReduceCallback callback, object initialValue) {
            return null;
        }

        [ScriptAlias("ss.remove")]
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

        public object Shift() {
            return null;
        }

        public Array Slice(int start) {
            return null;
        }

        public Array Slice(int start, int end) {
            return null;
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

        public void Splice(int start, int deleteCount) {
        }

        public void Splice(int start, int deleteCount, params object[] itemsToInsert) {
        }

        public void Unshift(params object[] items) {
        }

        public static implicit operator Array(ArrayList list) {
            return null;
        }

        public static implicit operator object[](ArrayList list) {
            return null;
        }

        public static implicit operator List<object>(ArrayList list) {
            return null;
        }

        public static explicit operator ArrayList(object[] array) {
            return null;
        }
    }
}
