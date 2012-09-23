// ClientRectList.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Html {

    [IgnoreNamespace]
    [ScriptImport]
    public sealed class ClientRectList {

        private ClientRectList() {
        }

        [ScriptProperty]
        public int Length {
            get {
                return 0;
            }
        }

        [ScriptProperty]
        public ClientRect this[int index] {
            get {
                return null;
            }
        }
    }
}
