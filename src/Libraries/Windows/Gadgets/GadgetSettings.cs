// GadgetSettings.cs
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
    /// Allows reading and writing settings for the gadget.
    /// </summary>
    [IgnoreNamespace]
    [Imported]
    public sealed class GadgetSettings {

        private GadgetSettings() {
        }

        public object Read(string name) {
            return null;
        }

        public string ReadString(string name) {
            return null;
        }

        public void Write(string name, object value) {
        }

        public void WriteString(string name, string value) {
        }
    }
}
