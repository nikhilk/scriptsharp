// GadgetSettings.cs
// Script#/Libraries/Windows
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
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
