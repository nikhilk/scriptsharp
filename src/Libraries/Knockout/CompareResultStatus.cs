// CompareResultStatus.cs
// Script#/Libraries/Knockout
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace System {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptConstants]
    public enum CompareResultStatus {

        Added,

        Deleted,

        Retained
    }
}
