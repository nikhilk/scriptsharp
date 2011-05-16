// IApplication.cs
// Script#/Libraries/CoreLib
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace System.ComponentModel {

    /// <summary>
    /// Defines contextual information about the current application.
    /// </summary>
    [Imported]
    [ScriptNamespace("ss")]
    public interface IApplication {

        /// <summary>
        /// Gets the value of the specified setting value.
        /// </summary>
        /// <param name="name">The name of the setting.</param>
        /// <returns>The value of the setting if it is available.</returns>
        string GetSetting(string name);
    }
}
