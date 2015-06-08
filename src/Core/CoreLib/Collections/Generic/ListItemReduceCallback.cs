// ListItemReduceCallback.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System.Collections.Generic {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate TReduced ListItemReduceCallback<TReduced, TValue>(TReduced previousValue, TValue value);
}
