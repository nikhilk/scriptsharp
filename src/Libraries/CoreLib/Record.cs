// Record.cs
// Script#/Libraries/CoreLib
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
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
