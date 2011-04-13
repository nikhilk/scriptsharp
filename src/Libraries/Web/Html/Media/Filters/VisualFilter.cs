// VisualFilter.cs
// Script#/Libraries/Web
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.Media.Filters {

    [IgnoreNamespace]
    [Imported]
    public class VisualFilter {

        internal VisualFilter() {
        }

        [IntrinsicProperty]
        public bool Enabled {
            get {
                return false;
            }
            set {
            }
        }
    }
}
