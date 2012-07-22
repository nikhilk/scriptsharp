// ListGrouping.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System.Collections.Generic {

    [IgnoreNamespace]
    [Imported]
    [ScriptName("Array")]
    public sealed class ListGrouping<T> : IReadonlyCollection<T> {

        private ListGrouping() {
        }

        [IntrinsicProperty]
        public string Key {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("length")]
        public int Count {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public T this[int index] {
            get {
                return default(T);
            }
        }
        public TAccumulated Aggregate<TAccumulated>(TAccumulated seed, ListAggregator<TAccumulated, T> aggregator) {
            return default(TAccumulated);
        }

        public TAccumulated Aggregate<TAccumulated>(TAccumulated seed, ListItemAggregator<TAccumulated, T> aggregator) {
            return default(TAccumulated);
        }

        public bool Contains(T item) {
            return false;
        }

        public bool Every(ListFilterCallback<T> filterCallback) {
            return false;
        }

        public bool Every(ListItemFilterCallback<T> itemFilterCallback) {
            return false;
        }

        public List<T> Extract(int index) {
            return null;
        }

        public List<T> Extract(int index, int count) {
            return null;
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

        public ListGrouping<T>[] GroupBy(ListItemKeyGenerator<T> keyCallback) {
            return null;
        }

        /*
        // HACK: This should be T instead of object, but we have a problem
        //       handling partial generic types in the compiler.
        public Dictionary<string, object> Index(ListItemKeyGenerator<T> keyCallback) {
            return null;
        }
        */

        public int IndexOf(T item) {
            return 0;
        }

        public int IndexOf(T item, int startIndex) {
            return 0;
        }

        public string Join() {
            return null;
        }

        public string Join(string delimiter) {
            return null;
        }

        public List<TTarget> Map<TTarget>(ListMapCallback<T, TTarget> mapCallback) {
            return null;
        }

        public List<TTarget> Map<TTarget>(ListItemMapCallback<T, TTarget> mapItemCallback) {
            return null;
        }

        public void Reverse() {
        }

        public bool Some(ListFilterCallback<T> filterCallback) {
            return false;
        }

        public bool Some(ListItemFilterCallback<T> itemFilterCallback) {
            return false;
        }
    }
}
