// FileSystemWatcher.cs
// Script#/Libraries/Node/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.IO {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public sealed class FileSystemWatcher : IEventEmitter {

        private FileSystemWatcher() {
        }

        [ScriptEvent("on", "removeListener")]
        public event Action<FileSystemChange, string> Change {
            add {
            }
            remove {
            }
        }

        public void Close() {
        }
    }
}
