// ScriptMode.cs
// Script#/Runtime/Server
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;

namespace ScriptSharp.Web {

    public enum ScriptMode {

        Startup = 0,

        Deferred = 1,

        OnDemand = 2
    }
}
