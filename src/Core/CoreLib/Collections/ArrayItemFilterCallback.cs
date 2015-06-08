// ArrayItemFilterCallback.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Collections {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate bool ArrayItemFilterCallback(object value);
}
