// ScriptInstance.cs
// Script#/Libraries/Node/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.Compute {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public sealed class ScriptInstance {

        private ScriptInstance() {
        }

        public object RunInNewContext() {
            return null;
        }

        public object RunInNewContext(object global) {
            return null;
        }

        public object RunInThisContext() {
            return null;
        }
    }
}
