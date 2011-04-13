// EnvironmentService.cs
// Script#/Libraries/Windows
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Gadgets {

    /// <summary>
    /// Represents the current machine.
    /// </summary>
    [IgnoreNamespace]
    [Imported]
    public static class EnvironmentService {

        [IntrinsicProperty]
        public static string MachineName {
            get {
                return null;
            }
        }

        public static string GetEnvironmentVariable(string name) {
            return null;
        }
    }
}
