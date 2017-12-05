// LineReader.cs
// Script#/Libraries/Node/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.IO {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptDependency("readline")]
    public sealed class LineReader : IEventEmitter {

        private LineReader() {
        }

        [ScriptEvent("on", "removeListener")]
        public event Action Close {
            add {
            }
            remove {
            }
        }

        [ScriptEvent("on", "removeListener")]
        [ScriptName("SIGINT")]
        public event Action Interrupt {
            add {
            }
            remove {
            }
        }

        [ScriptEvent("on", "removeListener")]
        public event Action<string> Line {
            add {
            }
            remove {
            }
        }

        [ScriptEvent("on", "removeListener")]
        public event Action Pause {
            add {
            }
            remove {
            }
        }

        [ScriptEvent("on", "removeListener")]
        public event Action Resume {
            add {
            }
            remove {
            }
        }

        public static LineReader CreateInterface(LineReaderOptions options) {
            return null;
        }

        [ScriptName("close")]
        public void CloseReader() {
        }

        [ScriptName("pause")]
        public void PauseReader() {
        }

        public void Prompt() {
        }

        public void Prompt(bool preserveCursor) {
        }

        [ScriptName("resume")]
        public void ResumeReader() {
        }

        public void Question(string query, Action<string> callback) {
        }

        public void SetPrompt(string prompt, int length) {
        }

        public void Write(string data) {
        }
    }
}
