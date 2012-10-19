// HttpServer.cs
// Script#/Libraries/Node/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;
using NodeApi.IO;

namespace NodeApi.Network {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public sealed class HttpServer : IEventEmitter {

        private HttpServer() {
        }

        [ScriptField]
        public int MaxHeaderCount {
            get;
            set;
        }

        [ScriptEvent("on", "removeListener")]
        public event Action<HttpServerRequest, HttpServerResponse> CheckContinue {
            add {
            }
            remove {
            }
        }

        [ScriptEvent("on", "removeListener")]
        public event Action<Exception> ClientError {
            add {
            }
            remove {
            }
        }

        [ScriptEvent("on", "removeListener")]
        public event Action Close {
            add {
            }
            remove {
            }
        }

        [ScriptEvent("on", "removeListener")]
        public event Action<HttpServerRequest, Socket, Buffer> Connect {
            add {
            }
            remove {
            }
        }

        [ScriptEvent("on", "removeListener")]
        public event Action<Socket> Connection {
            add {
            }
            remove {
            }
        }

        [ScriptEvent("on", "removeListener")]
        public event Action Listening {
            add {
            }
            remove {
            }
        }

        [ScriptEvent("on", "removeListener")]
        public event Action<HttpServerRequest, HttpServerResponse> Request {
            add {
            }
            remove {
            }
        }

        [ScriptEvent("on", "removeListener")]
        public event Action<HttpServerRequest, Socket, Buffer> Upgrade {
            add {
            }
            remove {
            }
        }

        public void Listen(int port) {
        }

        public void Listen(int port, string hostName) {
        }

        public void Listen(int port, string hostName, int backlog) {
        }
    }
}
