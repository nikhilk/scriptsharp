// MutableEvent.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public class WheelEvent : MouseEvent
    {
        [ScriptField]
        public extern double DeltaX { get; }

        [ScriptField]
        public extern double DeltaY { get; }

        [ScriptField]
        public extern double DeltaZ { get; }

        [ScriptField]
        public extern long DeltaMode { get; }
    }
}
