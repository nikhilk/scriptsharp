// Dictionary.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System.Collections.Generic {

    /// <summary>
    /// The Dictionary data type which is mapped to the Object type in Javascript.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("Object")]
    public sealed class Dictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>> {

        public Dictionary() {
        }

        public Dictionary(params object[] nameValuePairs) {
        }

        [Obsolete("This is only for use by the c# compiler, and cannot be used for generating script.", /* error */ true)]
        public Dictionary(int count) {
        }

        public int Count {
            get {
                return 0;
            }
        }

        public IReadonlyCollection<TKey> Keys {
            get {
                return null;
            }
        }

        [ScriptField]
        public TValue this[TKey key] {
            get {
                return default(TValue);
            }
            set {
            }
        }

        [Obsolete("This is only for use by the c# compiler, and cannot be used for generating script.", /* error */ true)]
        public void Add(TKey key, TValue value) {
        }

        [ScriptAlias("ss.clearKeys")]
        public void Clear() {
        }

        [ScriptAlias("ss.keyExists")]
        public bool ContainsKey(TKey key) {
            return false;
        }

        public static Dictionary<TKey, TValue> GetDictionary(object o) {
            return null;
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() {
            return null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return null;
        }

        public void Remove(TKey key) {
        }

        [Obsolete("This is only for use by the c# compiler, and cannot be used for generating script.", /* error */ true)]
        public bool TryGetValue(TKey key, out TValue value) {
            value = default(TValue);
            return false;
        }

        public static implicit operator Dictionary(Dictionary<TKey, TValue> dictionary) {
            return null;
        }

        public static implicit operator Dictionary<TKey, TValue>(Dictionary dictionary) {
            return null;
        }
    }
}
