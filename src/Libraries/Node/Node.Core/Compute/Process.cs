// Process.cs
// Script#/Libraries/Node/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NodeApi.IO;

namespace NodeApi.Compute {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public sealed class Process : IEventEmitter {

        private Process() {
        }

        [ScriptProperty]
        [ScriptName("arch")]
        public string Architecture {
            get {
                return String.Empty;
            }
        }

        [ScriptProperty]
        [ScriptName("argv")]
        public string[] Arguments {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("env")]
        public Dictionary<string, string> Environment {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public string ExecPath {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public string Platform {
            get {
                return String.Empty;
            }
        }

        [ScriptProperty]
        [ScriptName("pid")]
        public int ProcessID {
            get {
                return 0;
            }
        }

        [ScriptProperty]
        [ScriptName("stderr")]
        public WritableStream StandardError {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("stdin")]
        public ReadableStream StandardInput {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("stdout")]
        public WritableStream StandardOutput {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public string Title {
            get {
                return String.Empty;
            }
        }

        [ScriptProperty]
        public string Version {
            get {
                return null;
            }
        }

        [ScriptEvent("on", "removeListener")]
        public event Action Exit {
            add {
            }
            remove {
            }
        }

        [ScriptEvent("on", "removeListener")]
        public event Action<Exception> UncaughtException {
            add {
            }
            remove {
            }
        }

        [ScriptName("chdir")]
        public void ChangeDirectory(string directory) {
        }

        public void Abort() {
        }

        [ScriptName("exit")]
        public void ExitProcess() {
        }

        [ScriptName("exit")]
        public void ExitProcess(int code) {
        }

        [ScriptName("cwd")]
        public string GetCurrentDirectory() {
            return null;
        }

        public void Kill(int pid) {
        }

        public void NextTick(Action callback) {
        }
    }
}
