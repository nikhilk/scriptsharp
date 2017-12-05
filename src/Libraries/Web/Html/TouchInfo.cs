// TouchInfo.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class TouchInfo {

        internal TouchInfo() {
        }

        [ScriptField]
        public int ClientX {
            get {
                return 0;
            }
        }

        [ScriptField]
        public int ClientY {
            get {
                return 0;
            }
        }

        [ScriptField]
        public int Identifier {
            get {
                return 0;
            }
        }

        [ScriptField]
        public int PageX {
            get {
                return 0;
            }
        }

        [ScriptField]
        public int PageY {
            get {
                return 0;
            }
        }

        [ScriptField]
        public int ScreenX {
            get {
                return 0;
            }
        }

        [ScriptField]
        public long ScreenY {
            get {
                return 0;
            }
        }

        [ScriptField]
        public Element Target {
            get {
                return null;
            }
        }
    }
}
