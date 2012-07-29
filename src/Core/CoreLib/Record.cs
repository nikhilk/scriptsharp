// Record.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System {

    [Imported]
    [ScriptNamespace("ss")]
    public abstract class Record {

        /// <internalonly />
        public static implicit operator Dictionary(Record r) {
            return null;
        }

        /// <internalonly />
        public static implicit operator Dictionary<string, object>(Record r) {
            return null;
        }

        /// <internalonly />
        public static implicit operator Record(Dictionary d) {
            return null;
        }

        /// <internalonly />
        public static implicit operator Record(Dictionary<string, object> d) {
            return null;
        }
    }
}
