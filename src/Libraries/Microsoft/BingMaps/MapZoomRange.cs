// MapZoomRange.cs
// Script#/Libraries/Microsoft/BingMaps
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps {

    [Imported]
    [ScriptName("Object")]
    [IgnoreNamespace]
    public sealed class MapZoomRange {

        [IntrinsicProperty]
        public int Min {
            get;
            set;
        }

        [IntrinsicProperty]
        public int Max {
            get;
            set;
        }
    }
}
