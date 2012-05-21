// ClientRectList.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Html {

    [IgnoreNamespace]
    [Imported]
    public sealed class ClientRectList {

        private ClientRectList() {
        }

        [IntrinsicProperty]
        public int Length {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public ClientRect this[int index] {
            get {
                return null;
            }
        }
    }
}
