// ClientRect.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Html {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class ClientRect {

        private ClientRect() {
        }

        [ScriptField]
        public double Bottom {
            get {
                return 0;
            }
        }

        [ScriptField]
        public double Left {
            get {
                return 0;
            }
        }

        [ScriptField]
        public double Right {
            get {
                return 0;
            }
        }

        [ScriptField]
        public double Top {
            get {
                return 0;
            }
        }
    }
}
