// ReadyState.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;
using System.Xml;

namespace System.Net {

    [IgnoreNamespace]
    [Imported]
    [NumericValues]
    public enum ReadyState {

        Uninitialized = 0,

        Open = 1,

        Sent = 2,

        Receiving = 3,

        Loaded = 4
    }
}
