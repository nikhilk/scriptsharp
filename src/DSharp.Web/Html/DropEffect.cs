// DropEffect.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptConstants(UseNames = true)]
    public enum DropEffect {

        Copy = 0,

        Link = 1,

        Move = 2,

        None = 3
    }
}
