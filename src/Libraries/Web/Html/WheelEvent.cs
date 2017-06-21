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
        public extern double DeltaX { get; }
        
        public extern double DeltaY { get; }

        public extern double DeltaZ { get; }

        public extern long DeltaMode { get; }
    }
}
