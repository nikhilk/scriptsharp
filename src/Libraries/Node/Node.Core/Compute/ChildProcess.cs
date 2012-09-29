// Process.cs
// Script#/Libraries/Node/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.Compute {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptDependency("child_process")]
    [ScriptName("child_process")]
    public sealed class ChildProcess : IEventEmitter {

        private ChildProcess() {
        }
    }
}
