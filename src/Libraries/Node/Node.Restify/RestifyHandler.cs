// RestifyHandler.cs
// Script#/Libraries/Node/Restify
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.Restify {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public delegate void RestifyHandler(RestifyRequest request, RestifyResponse response);

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public delegate RestifyChainedHandler RestifyChainedHandler(RestifyRequest request, RestifyResponse response, Func<bool, RestifyChainedHandler> next);
}
