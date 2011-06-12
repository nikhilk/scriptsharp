// ClientRect.cs
// Script#/Libraries/Web
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Html {

    [IgnoreNamespace]
    [Imported]
    public sealed class ClientRect {

        private ClientRect() {
        }

        [IntrinsicProperty]
        public double Bottom {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public double Left {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public double Right {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public double Top {
            get {
                return 0;
            }
        }
    }
}
