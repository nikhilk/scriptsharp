// IInitializable.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.ComponentModel {

    /// <summary>
    /// Implemented by objects that supports a simple, transacted notification for batch
    /// initialization. 
    /// </summary>
    [ScriptImport]
    public interface IInitializable {

        /// <summary>
        /// Signals the object that initialization is starting.
        /// </summary>
        /// <param name="options">An optional set of name/value pairs containing initialization data.</param>
        void BeginInitialization(Dictionary<string, object> options);

        /// <summary>
        /// Signals the object that initialization is complete.
        /// </summary>
        void EndInitialization();
    }
}
