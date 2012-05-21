// KeyValuePair.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
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
