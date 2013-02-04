// REPLEvaluator.cs
// Script#/Libraries/Node/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.IO {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public delegate void REPLEvaluator(string command, object context, string fileName, AsyncResultCallback<object> callback);
}
