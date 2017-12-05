// RoleStatus.cs
// Script#/Libraries/Node/Azure
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.WindowsAzure.Runtime {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptConstants(UseNames = true)]
    public enum RoleStatus {

        Busy = 0,

        Ready = 1
    }
}
