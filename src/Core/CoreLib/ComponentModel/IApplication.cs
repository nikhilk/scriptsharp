// IApplication.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.ComponentModel {

    /// <summary>
    /// Defines contextual information about the current application.
    /// </summary>
    [ScriptImport]
    public interface IApplication {

        /// <summary>
        /// Gets the value of the specified setting value.
        /// </summary>
        /// <param name="name">The name of the setting.</param>
        /// <returns>The value of the setting if it is available.</returns>
        string GetSetting(string name);
    }
}
