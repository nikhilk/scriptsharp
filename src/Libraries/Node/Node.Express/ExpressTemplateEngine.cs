// ExpressTemplateEngine.cs
// Script#/Libraries/Node/Express
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.ExpressJS {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public delegate void ExpressTemplateEngine(string path, object locals, AsyncResultCallback<string> callback);
}
