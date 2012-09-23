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

        [ScriptProperty]
        public TouchInfo[] ChangedTouches {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public TouchInfo[] TargetTouches {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public TouchInfo[] Touches {
            get {
                return null;
            }
        }
    }
}
