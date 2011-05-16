// Dictionary.cs
// Script#/Libraries/CoreLib
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Collections {

    /// <summary>
    /// The Dictionary data type which is mapped to the Object type in Javascript.
    /// </summary>
    [IgnoreNamespace]
    [Imported]
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

        [IntrinsicProperty]
        public object this[string key] {
            get {
                return null;
            }
            set {
            }
        }

        public void Clear() {
        }

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
