// MessageEvent.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class MessageEvent : ElementEvent {

        internal MessageEvent() {
        }

        [ScriptField]
        public string Data {
            get {
                return null;
            }
        }

        [ScriptField]
        public string Origin {
            get {
                return null;
            }
        }

        [ScriptField]
        public WindowInstance Source {
            get {
                return null;
            }
        }
    }
}
