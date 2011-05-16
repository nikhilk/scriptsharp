// EventArgs.cs
// Script#/Libraries/CoreLib
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System.Runtime.CompilerServices;

namespace System {

    /// <summary>
    /// Used by event sources to pass event argument information.
    /// </summary>
    [ScriptNamespace("ss")]
    [Imported]
    public class EventArgs {

        /// <summary>
        /// A static object of type <see cref="EventArgs"/> that is used as a convenient way to
        /// specify an empty EventArgs instance.
        /// </summary>
        [PreserveCase]
        public static readonly EventArgs Empty = null;
    }
}
