// Dictionary.cs
// Script#/Libraries/CoreLib
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System.Runtime.CompilerServices;

namespace System.Collections.Generic {

    /// <summary>
    /// The Dictionary data type which is mapped to the Object type in Javascript.
    /// </summary>
    [IgnoreNamespace]
    [Imported]
    [ScriptName("Object")]
    public sealed class Dictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>> {

        public Dictionary() {
        }

        public Dictionary(params object[] nameValuePairs) {
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

        [IntrinsicProperty]
        public TValue this[TKey key] {
            get {
                return default(TValue);
            }
            set {
            }
        }

        public void Clear() {
        }

        public bool ContainsKey(TKey key) {
            return false;
        }

        public static Dictionary<TKey, TValue> GetDictionary(object o) {
            return null;
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() {
            return null;
        }

        public void Remove(TKey key) {
        }

        public static implicit operator Dictionary(Dictionary<TKey, TValue> dictionary) {
            return null;
        }

        public static implicit operator Dictionary<TKey, TValue>(Dictionary dictionary) {
            return null;
        }
    }
}
