// TouchEvent.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class TouchEvent : ElementEvent {

        internal TouchEvent() {
        }

        [ScriptField]
        public TouchInfo[] ChangedTouches {
            get {
                return null;
            }
        }

        [ScriptField]
        public TouchInfo[] TargetTouches {
            get {
                return null;
            }
        }

        [ScriptField]
        public TouchInfo[] Touches {
            get {
                return null;
            }
        }
    }
}
