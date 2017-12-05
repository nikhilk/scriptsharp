// HttpServer.cs
// Script#/Tools/Testing
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ScriptSharp.Testing.WebServer {

    internal abstract class HttpServer {

        private int _port;
        private Action<HttpMessage> _getHandler;
        private Action<HttpMessage> _postHandler;

        private bool _alive;

        protected void Initialize(Action<HttpMessage> getHandler, Action<HttpMessage> postHandler) {
            _getHandler = getHandler;
            _postHandler = postHandler;
        }

        private void Run() {
            TcpListener listener = new TcpListener(new IPEndPoint(IPAddress.Loopback, _port));
            listener.Start();

            while (_alive) {
                try {
                    if (listener.Pending()) {
                        TcpClient client = listener.AcceptTcpClient();

                        HttpMessage message = new HttpMessage(this, _getHandler, _postHandler);
                        message.ProcessClient(client);
                    }
                }
                catch {
                }

                Thread.Sleep(1);
            }

            listener.Stop();
        }

        public void Start(int port) {
            if (_alive) {
                throw new InvalidOperationException();
            }

            _alive = true;
            _port = port;

            Thread mainThread = new Thread(Run);
            mainThread.Start();
        }

        public void Stop() {
            _alive = false;
        }
    }
}
