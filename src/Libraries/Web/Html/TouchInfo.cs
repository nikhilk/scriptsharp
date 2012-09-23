// TouchInfo.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [IgnoreNamespace]
    [Imported]
    public sealed class TouchInfo {

        internal TouchInfo() {
        }

        [ScriptProperty]
        public int ClientX {
            get {
                return 0;
            }
        }

        [ScriptProperty]
        public int ClientY {
            get {
                return 0;
            }
        }

        [ScriptProperty]
        public int Identifier {
            get {
                return 0;
            }
        }

        [ScriptProperty]
        public int PageX {
            get {
                return 0;
            }
        }

        [ScriptProperty]
        public int PageY {
            get {
                return 0;
            }
        }

        [ScriptProperty]
        public int ScreenX {
            get {
                return 0;
            }
        }

        [ScriptProperty]
        public long ScreenY {
            get {
                return 0;
            }
        }

        [ScriptProperty]
        public Element Target {
            get {
                return null;
            }
        }
    }
}
