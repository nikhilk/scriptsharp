// AccordionChangeEvent.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Object")]
    public sealed class AccordionChangeEvent {

        [ScriptField]
        public object NewContent {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public object NewHeader {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public object OldContent {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public object OldHeader {
            get {
                return null;
            }
            set {
            }
        }
    }
}
