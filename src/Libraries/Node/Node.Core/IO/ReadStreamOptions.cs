// ReadStreamOptions.cs
// Script#/Libraries/Node/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.IO {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Object")]
    public sealed class ReadStreamOptions {

        [ScriptProperty]
        public int BufferSize {
            get;
            set;
        }

        [ScriptProperty]
        public Encoding Encoding {
            get;
            set;
        }

        [ScriptProperty]
        [ScriptName("fd")]
        public FileDescriptor FileDescriptor {
            get;
            set;
        }

        [ScriptProperty]
        public string Flags {
            get;
            set;
        }

        [ScriptProperty]
        public int Mode {
            get;
            set;
        }
    }
}
