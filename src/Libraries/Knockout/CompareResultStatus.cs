// CompareResultStatus.cs
// Script#/Libraries/Knockout
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace System {

    // This doesn't map to an actual type, but needs to be present
    // in the set of types, so that the C# void type can be mapped
    [IgnoreNamespace]
    [Imported]
    [NamedValues]
    public enum CompareResultStatus {

        Added,

        Deleted,

        Retained
    }
}
