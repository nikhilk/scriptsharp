// DocumentImplementation.cs
// Script#/Libraries/Web
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
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
