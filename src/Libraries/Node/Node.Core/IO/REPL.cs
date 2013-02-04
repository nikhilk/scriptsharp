// REPL.cs
// Script#/Libraries/Node/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.IO {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptDependency("repl")]
    public sealed class REPL {

        private REPL() {
        }

        [ScriptEvent("on", "removeListener")]
        public event Action Exit {
            add {
            }
            remove {
            }
        }

        public REPL Start(object options) {
            return null;
        }
    }
}
