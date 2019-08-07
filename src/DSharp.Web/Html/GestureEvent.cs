// GestureEvent.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class GestureEvent : ElementEvent {

        internal GestureEvent() {
        }

        [ScriptField]
        public double Rotation {
            get {
                return 0;
            }
        }

        [ScriptField]
        public double Scale {
            get {
                return 0;
            }
        }
    }
}
