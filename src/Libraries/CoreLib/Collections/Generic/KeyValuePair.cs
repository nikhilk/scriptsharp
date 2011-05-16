// KeyValuePair.cs
// Script#/Libraries/CoreLib
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System.Runtime.CompilerServices;

namespace System.Collections.Generic {

    [IgnoreNamespace]
    [Imported]
    [ScriptName("Object")]
    public sealed class KeyValuePair<TKey, TValue> {

        internal KeyValuePair() {
        }

        [IntrinsicProperty]
        public TKey Key {
            get {
                return default(TKey);
            }
        }

        [IntrinsicProperty]
        public TValue Value {
            get {
                return default(TValue);
            }
        }
    }
}
