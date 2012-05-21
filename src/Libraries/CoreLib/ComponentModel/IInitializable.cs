// IInitializable.cs
// Script#/Libraries/CoreLib
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.ComponentModel {

    /// <summary>
    /// Implemented by objects that supports a simple, transacted notification for batch
    /// initialization. 
    /// </summary>
    [Imported]
    [ScriptNamespace("ss")]
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
