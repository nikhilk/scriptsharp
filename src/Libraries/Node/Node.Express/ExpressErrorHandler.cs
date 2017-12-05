// ExpressErrorHandler.cs
// Script#/Libraries/Node/Express
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.ExpressJS {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public delegate void ExpressErrorHandler(Exception error, ExpressServerRequest request, ExpressServerResponse response);

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public delegate void ExpressChainedErrorHandler(Exception error, ExpressServerRequest request, ExpressServerResponse response, ExpressChain next);
}
