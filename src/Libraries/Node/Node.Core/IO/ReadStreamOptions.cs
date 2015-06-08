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

        [ScriptField]
        public int BufferSize {
            get;
            set;
        }

        [ScriptField]
        public Encoding Encoding {
            get;
            set;
        }

        [ScriptField]
        [ScriptName("fd")]
        public FileDescriptor FileDescriptor {
            get;
            set;
        }

        [ScriptField]
        public string Flags {
            get;
            set;
        }

        [ScriptField]
        public int Mode {
            get;
            set;
        }
    }
}
