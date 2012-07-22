// EventArgs.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
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
