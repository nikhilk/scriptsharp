// ReadyState.cs
// Script#/Libraries/Web
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
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
