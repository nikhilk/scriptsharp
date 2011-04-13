// MapMouseEventArgs.cs
// Script#/Libraries/Microsoft/BingMaps
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Collections;
using System.Html;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps {

    // TODO: Make properties

    [Imported]
    [IgnoreNamespace]
    public sealed class MapMouseEventArgs : MapEventArgs {

        private MapMouseEventArgs() {
        }

        public bool Handled;
        public bool IsTouchEvent;
        public int PageX;
        public int PageY;
        public object Target;
        public string TargetType;
        public int WheelDelta;
        public bool IsPrimary;
        public bool IsSecondary;

        public int GetX() {
            return 0;
        }

        public int GetY() {
            return 0;
        }
    }
}
