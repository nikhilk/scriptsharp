// ReadStream.cs
// Script#/Libraries/Node/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.IO {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public sealed class ReadStream : ReadableStream {

        private ReadStream() {
        }

        [ScriptEvent("on", "removeListener")]
        public event Action Open {
            add {
            }
            remove {
            }
        }
    }
}
