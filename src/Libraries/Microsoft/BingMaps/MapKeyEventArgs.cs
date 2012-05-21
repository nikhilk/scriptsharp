// MapKeyEventArgs.cs
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
    public sealed class MapKeyEventArgs : MapEventArgs {

        private MapKeyEventArgs() {
        }

        public bool Handled;
        public int KeyCode;
        public bool AltKey;
        public bool CtrlKey;
        public bool ShiftKey;
    }
}
