// FileSystemWatchOptions.cs
// Script#/Libraries/Node/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.IO {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Object")]
    public sealed class FileSystemWatchOptions {

        [ScriptProperty]
        public bool Persistent {
            get;
            set;
        }
    }
}
