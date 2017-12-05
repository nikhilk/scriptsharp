// CancelEventArgs.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System {

    /// <summary>
    /// The event argument associated with cancelable events.
    /// </summary>
    [ScriptImport]
    public class CancelEventArgs : EventArgs {

        /// <summary>
        /// Whether the event has been canceled.
        /// </summary>
        [ScriptField]
        public bool Cancel {
            get {
                return false;
            }
            set {
            }
        }
    }
}
