// GestureEvent.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [IgnoreNamespace]
    [Imported]
    public sealed class GestureEvent : ElementEvent {

        internal GestureEvent() {
        }

        [IntrinsicProperty]
        public double Rotation {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public double Scale {
            get {
                return 0;
            }
        }
    }
}
