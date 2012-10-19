// Dictionary.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Collections {

    /// <summary>
    /// The Dictionary data type which is mapped to the Object type in Javascript.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("Object")]
    public sealed class Dictionary : IEnumerable {

        public Dictionary() {
        }

        public Dictionary(params object[] nameValuePairs) {
        }

        public int Count {
            get {
                return 0;
            }
        }

        public string[] Keys {
            get {
                return null;
            }
        }

        [ScriptField]
        public object this[string key] {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptAlias("ss.clearKeys")]
        public void Clear() {
        }

        [ScriptAlias("ss.keyExists")]
        public bool ContainsKey(string key) {
            return false;
        }

        public static Dictionary GetDictionary(object o) {
            return null;
        }

        public void Remove(string key) {
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return null;
        }
    }
}
