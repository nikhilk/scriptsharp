// HttpClientRequest.cs
// Script#/Libraries/Node/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;
using NodeApi.IO;

namespace NodeApi.Network {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public sealed class HttpClientRequest : WritableStream {

        private HttpClientRequest() {
        }

        [ScriptEvent("on", "removeListener")]
        public event Action<HttpClientResponse> Response {
            add {
            }
            remove {
            }
        }

        [ScriptEvent("on", "removeListener")]
        public event Action<HttpClientResponse, Socket, Buffer> Connect {
            add {
            }
            remove {
            }
        }

        [ScriptEvent("on", "removeListener")]
        public event Action Continue {
            add {
            }
            remove {
            }
        }

        [ScriptEvent("on", "removeListener")]
        public event Action<Socket> Socket {
            add {
            }
            remove {
            }
        }

        [ScriptEvent("on", "removeListener")]
        public event Action Timeout {
            add {
            }
            remove {
            }
        }

        [ScriptEvent("on", "removeListener")]
        public event Action<HttpClientResponse, Socket, Buffer> Upgrade {
            add {
            }
            remove {
            }
        }

        public void Abort() {
        }

        public void SetTimeout(int timeout) {
        }

        public void SetNoDelay() {
        }

        public void SetNoDelay(bool noDelay) {
        }

        public void SetSocketKeepAlive() {
        }

        public void SetSocketKeepAlive(bool enable) {
        }

        public void SetSocketKeepAlive(bool enable, int initialDelay) {
        }

        public void SetTimeout(int timeout, Action timeoutCallback) {
        }
    }
}
