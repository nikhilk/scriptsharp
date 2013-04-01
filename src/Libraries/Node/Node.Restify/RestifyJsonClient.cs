// RestifyJsonClient.cs
// Script#/Libraries/Node/Restify
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections;
using System.Runtime.CompilerServices;

namespace NodeApi.Restify {

    /// <summary>
    /// sends and expects application/json
    /// </summary>
    [ScriptImport]
    [ScriptIgnoreNamespace]
    public sealed class RestifyJsonClient : RestifyStringClient {

        private RestifyJsonClient() {
        }
    }
}
