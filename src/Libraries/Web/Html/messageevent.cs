// MessageEvent.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [IgnoreNamespace]
    [Imported]
    public sealed class MessageEvent : ElementEvent {

        internal MessageEvent() {
        }

        [IntrinsicProperty]
        public string Data {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public string Origin {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public WindowInstance Source {
            get {
                return null;
            }
        }
    }
}
