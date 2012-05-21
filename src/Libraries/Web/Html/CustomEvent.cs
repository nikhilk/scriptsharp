// CustomEvent.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [IgnoreNamespace]
    [Imported]
    public sealed class CustomEvent : ElementEvent {

        internal CustomEvent() {
        }

        [IntrinsicProperty]
        public object Data {
            get {
                return null;
            }
        }
    }
}
