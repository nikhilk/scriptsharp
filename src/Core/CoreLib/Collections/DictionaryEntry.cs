// DictionaryEntry.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Collections {

    [IgnoreNamespace]
    [Imported]
    public sealed class DictionaryEntry {

        internal DictionaryEntry() {
        }

        [IntrinsicProperty]
        public string Key {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public object Value {
            get {
                return null;
            }
        }
    }
}
