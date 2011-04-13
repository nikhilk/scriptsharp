// Storage.cs
// Script#/Libraries/Web
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data {

    [IgnoreNamespace]
    [Imported]
    public sealed class Storage {

        private Storage() {
        }

        [IntrinsicProperty]
        public int Length {
            get {
                return 0;
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

        public object GetItem(string key) {
            return null;
        }

        [ScriptName("key")]
        public string GetKey(int index) {
            return null;
        }

        public void RemoveItem(string key) {
        }

        public void SetItem(string key, object value) {
        }
    }
}
