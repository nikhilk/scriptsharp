// MapMouseEventArgs.cs
// Script#/Libraries/Microsoft/BingMaps
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
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
