// jQueryPosition.cs
// Script#/Libraries/jQuery/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;
using System.Collections;

namespace jQueryApi {

    /// <summary>
    /// Provides information about the position of an element.
    /// </summary>
    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Object")]
    public sealed class jQueryPosition {

        public jQueryPosition() {
        }

        public jQueryPosition(params object[] nameValuePairs) {
        }

        /// <summary>
        /// Gets the left coordinate.
        /// </summary>
        [ScriptField]
        public int Left {
            get {
                return 0;
            }
            set {
            }
        }

        /// <summary>
        /// Gets the top coordinate.
        /// </summary>
        [ScriptField]
        public int Top {
            get {
                return 0;
            }
            set {
            }
        }

        public static implicit operator jQueryPosition(Dictionary position) {
            return null;
        }
    }
}
