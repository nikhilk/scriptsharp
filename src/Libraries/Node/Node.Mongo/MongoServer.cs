// MongoServer.cs
// Script#/Libraries/Node/Mongo
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.MongoDB {

    [ScriptImport]
    [ScriptName("Server")]
    public sealed class MongoServer {

        public MongoServer(string host, int port) {
        }

        public MongoServer(string host, int port, object options) {
        }
    }
}
