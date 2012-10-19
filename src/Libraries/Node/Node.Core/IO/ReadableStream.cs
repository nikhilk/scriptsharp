// ReadableStream.cs
// Script#/Libraries/Node/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.IO {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public abstract class ReadableStream : IEventEmitter {

        [ScriptField]
        public bool Readable {
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
        public event Action<string> Data {
            add {
            }
            remove {
            }
        }

        [ScriptEvent("on", "removeListener")]
        [ScriptName("data")]
        public event Action<Buffer> DataBuffer {
            add {
            }
            remove {
            }
        }

        [ScriptEvent("on", "removeListener")]
        public event Action End {
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

        public void Destroy() {
        }

        public void SetEncoding() {
        }

        public void SetEncoding(Encoding encoding) {
        }

        public void Pause() {
        }

        public WritableStream Pipe(WritableStream destination) {
            return null;
        }

        public WritableStream Pipe(WritableStream destination, object options) {
            return null;
        }

        public void Resume() {
        }
    }
}
