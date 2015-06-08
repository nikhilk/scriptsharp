// IPAddressType.cs
// Script#/Libraries/Node/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.Network {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptConstants]
    public enum IPAddressType {

        Invalid = 0,

        IPv4 = 4,

        IPv6 = 6
    }
}
