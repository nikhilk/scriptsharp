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
    public sealed class jQueryPosition {

        private jQueryPosition() {
        }

        /// <summary>
        /// Gets the left coordinate.
        /// </summary>
        [ScriptField]
        public int Left {
            get {
                return 0;
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
        }

        public static implicit operator Dictionary(jQueryPosition position) {
            return null;
        }
    }
}
