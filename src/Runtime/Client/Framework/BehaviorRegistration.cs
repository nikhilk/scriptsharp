// BehaviorRegistration.cs
// Script#/Runtime/Client/Framework
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace Sharpen {

    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    internal sealed class BehaviorRegistration {

        public Type BehaviorType = null;
        public Type ServiceType = null;
    }
}
