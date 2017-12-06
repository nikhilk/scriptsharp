// List.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System.Collections.Generic {

    // NOTE: Keep in sync with ArrayList and Array

    /// <summary>
    /// Equivalent to the Array type in Javascript.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("Array")]
    public sealed class List<T> : ICollection<T> {

        public List() {
        }

        public List(int capacity) {
        }

        public List(params T[] items) {
        }

        [ScriptField]
        [ScriptName("length")]
        public int Count {
            get {
                return 0;
            }
        }

        [ScriptField]
        public T this[int index] {
            get {
                return default(T);
            }
            set {
            }
        }

        [ScriptName("push")]
        public void Add(T item) {
        }

        [ScriptName("push")]
        public void AddRange(params T[] items) {
        }

        public void Clear() {
        }

        public List<T> Concat(params T[] objects) {
            return null;
        }

        public bool Contains(object item) {
            return false;
        }

        public bool Every(ListFilterCallback<T> filterCallback) {
            return false;
        }

        public bool Every(ListItemFilterCallback<T> itemFilterCallback) {
            return false;
        }

        public List<T> Filter(ListFilterCallback<T> filterCallback) {
            return null;
        }

        public List<T> Filter(ListItemFilterCallback<T> itemFilterCallback) {
            return null;
        }

        public void ForEach(ListCallback<T> callback) {
        }

        public void ForEach(ListItemCallback<T> itemCallback) {
        }

        public IEnumerator<T> GetEnumerator() {
            return null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return null;
        }

        public List<T> GetRange(int index) {
            return null;
        }

        public List<T> GetRange(int index, int count) {
            return null;
        }

        public int IndexOf(T item) {
            return 0;
        }

        public int IndexOf(T item, int startIndex) {
            return 0;
        }

        public void Insert(int index, T item) {
        }

        public void InsertRange(int index, params T[] items) {
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

        public List<TTarget> Map<TTarget>(ListMapCallback<T, TTarget> mapCallback) {
            return null;
        }

        public List<TTarget> Map<TTarget>(ListItemMapCallback<T, TTarget> mapItemCallback) {
            return null;
        }

        public static List<T> Parse(string s) {
            return null;
        }

        public TReduced Reduce<TReduced>(ListReduceCallback<TReduced, T> callback) {
            return default(TReduced);
        }

        public TReduced Reduce<TReduced>(ListReduceCallback<TReduced, T> callback, TReduced initialValue) {
            return default(TReduced);
        }

        public TReduced Reduce<TReduced>(ListItemReduceCallback<TReduced, T> callback) {
            return default(TReduced);
        }

        public TReduced Reduce<TReduced>(ListItemReduceCallback<TReduced, T> callback, TReduced initialValue) {
            return default(TReduced);
        }

        public TReduced ReduceRight<TReduced>(ListReduceCallback<TReduced, T> callback) {
            return default(TReduced);
        }

        public TReduced ReduceRight<TReduced>(ListReduceCallback<TReduced, T> callback, TReduced initialValue) {
            return default(TReduced);
        }

        public TReduced ReduceRight<TReduced>(ListItemReduceCallback<TReduced, T> callback) {
            return default(TReduced);
        }

        public TReduced ReduceRight<TReduced>(ListItemReduceCallback<TReduced, T> callback, TReduced initialValue) {
            return default(TReduced);
        }

        [ScriptAlias("ss.remove")]
        public bool Remove(T item) {
            return false;
        }

        public void RemoveAt(int index) {
        }

        public List<T> RemoveRange(int index, int count) {
            return null;
        }

        public void Reverse() {
        }

        public List<T> Slice(int start) {
            return null;
        }

        public List<T> Slice(int start, int end) {
            return null;
        }

        public bool Some(ListFilterCallback<T> filterCallback) {
            return false;
        }

        public bool Some(ListItemFilterCallback<T> itemFilterCallback) {
            return false;
        }

        public void Sort() {
        }

        public void Sort(CompareCallback<T> compareCallback) {
        }

        public void Splice(int start, int deleteCount) {
        }

        public void Splice(int start, int deleteCount, params T[] itemsToInsert) {
        }

        public void Unshift(params T[] items) {
        }

        [ScriptSkip]
        public T[] ToArray()
        {
            return null;
        }

        public static explicit operator Array(List<T> list) {
            return null;
        }

        public static explicit operator object[](List<T> list) {
            return null;
        }

        public static implicit operator T[](List<T> list) {
            return null;
        }

        public static explicit operator ArrayList(List<T> list) {
            return null;
        }

        public static explicit operator List<T>(T[] array) {
            return null;
        }
    }
}
