// ErrorHandler.cs
// Script#/Libraries/Web
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    /// <summary>
    /// Delegate for the window unhandled exception handler.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <param name="url">The URL of the script where the error occurred.</param>
    /// <param name="line">The line number where the error occurred.</param>
    /// <returns>true if the error was handled; false otherwise.</returns>
    [IgnoreNamespace]
    [Imported]
    public delegate bool ErrorHandler(string message, string url, int line);
}
