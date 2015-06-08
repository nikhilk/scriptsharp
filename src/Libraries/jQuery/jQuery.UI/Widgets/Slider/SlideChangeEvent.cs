// SlideChangeEvent.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Object")]
    public sealed class SlideChangeEvent {

        [ScriptField]
        public jQueryObject Handle {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public int Value {
            get {
                return 0;
            }
            set {
            }
        }
    }
}
