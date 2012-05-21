// TouchEvent.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [IgnoreNamespace]
    [Imported]
    public sealed class TouchEvent : ElementEvent {

        internal TouchEvent() {
        }

        [IntrinsicProperty]
        public TouchInfo[] ChangedTouches {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public TouchInfo[] TargetTouches {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public TouchInfo[] Touches {
            get {
                return null;
            }
        }
    }
}
