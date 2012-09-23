// CompareCallback.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System.Collections.Generic {

    [IgnoreNamespace]
    [ScriptImport]
    public delegate int CompareCallback<T>(T x, T y);
}
