// BehaviorRegistration.cs
// Script#/FX/Sharpen/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace Sharpen.Html {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Object")]
    internal sealed class BehaviorRegistration {

        public Type BehaviorType = null;
        public Type ServiceType = null;
    }
}
