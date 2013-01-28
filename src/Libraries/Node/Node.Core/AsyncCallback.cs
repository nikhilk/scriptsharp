// AsyncCallback.cs
// Script#/Libraries/Node/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;
using NodeApi.Compute;

namespace NodeApi {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public delegate void AsyncCallback(Exception error);

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public delegate void AsyncResultCallback<TResult>(Exception error, TResult result);

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public delegate void AsyncResultCallback<TResult1, TResult2>(Exception error, TResult1 result1, TResult2 result2);
}
