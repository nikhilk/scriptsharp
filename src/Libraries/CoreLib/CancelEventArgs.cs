// CancelEventArgs.cs
// Script#/Libraries/CoreLib
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace System {

    /// <summary>
    /// The event argument associated with cancelable events.
    /// </summary>
    [ScriptNamespace("ss")]
    [Imported]
    public class CancelEventArgs : EventArgs {

        /// <summary>
        /// Whether the event has been canceled.
        /// </summary>
        [IntrinsicProperty]
        public bool Cancel {
            get {
                return false;
            }
            set {
            }
        }
    }
}
