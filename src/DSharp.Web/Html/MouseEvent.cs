// MutableEvent.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public class MouseEvent : UIEvent {

        [ScriptField]
        public extern int X { get; }

        [ScriptField]
        public extern int Y { get; }
    }
}
