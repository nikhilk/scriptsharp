// Screen.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    /// <summary>
    /// The screen object represents information about the current desktop.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    public class Screen {

        [ScriptField]
        public int AvailHeight {
            get {
                return 0;
            }
        }

        [ScriptField]
        public int AvailWidth {
            get {
                return 0;
            }
        }

        [ScriptField]
        public int ColorDepth {
            get {
                return 0;
            }
        }

        [ScriptField]
        public int Height {
            get {
                return 0;
            }
        }

        [ScriptField]
        public int Width {
            get {
                return 0;
            }
        }
    }
}
