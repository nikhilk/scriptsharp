// LineReaderOptions.cs
// Script#/Libraries/Node/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.IO {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Object")]
    public sealed class LineReaderOptions {

        public LineReaderOptions() {
        }

        public LineReaderOptions(params object[] nameValuePairs) {
        }

        [ScriptField]
        public ReadableStream Input {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public WritableStream Output {
            get {
                return null;
            }
            set {
            }
        }
    }
}
