// DocumentImplementation.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [IgnoreNamespace]
    [Imported]
    public sealed class DocumentImplementation {

        internal DocumentImplementation() {
        }

        public bool HasFeature(string feature) {
            return false;
        }

        public bool HasFeature(string feature, string version) {
            return false;
        }
    }
}
