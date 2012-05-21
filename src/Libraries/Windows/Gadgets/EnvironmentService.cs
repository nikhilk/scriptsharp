// EnvironmentService.cs
// Script#/Libraries/Windows
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
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
