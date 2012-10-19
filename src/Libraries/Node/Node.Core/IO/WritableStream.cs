// WritableStream.cs
// Script#/Libraries/Node/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.IO {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public abstract class WritableStream : IEventEmitter {

        [ScriptField]
        public bool Writable {
            get {
                return false;
            }
        }

        [ScriptEvent("on", "removeListener")]
        public event Action Close {
            add {
            }
            remove {
            }
        }

        [ScriptEvent("on", "removeListener")]
        public event Action Drain {
            add {
            }
            remove {
            }
        }

        [ScriptEvent("on", "removeListener")]
        public event Action<Exception> Error {
            add {
            }
            remove {
            }
        }

        [ScriptEvent("on", "removeListener")]
        public event Action<ReadableStream> Pipe {
            add {
            }
            remove {
            }
        }

        public void Destroy() {
        }

        public void DestroySoon() {
        }

        public void End() {
        }

        public void End(string data) {
        }

        public void End(string data, Encoding encoding) {
        }

        public void End(Buffer data) {
        }

        public bool Write(string content) {
            return false;
        }

        public bool Write(string content, Encoding encoding) {
            return false;
        }

        public bool Write(Buffer buffer) {
            return false;
        }
    }
}
