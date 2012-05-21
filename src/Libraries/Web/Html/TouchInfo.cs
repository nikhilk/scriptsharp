// TouchInfo.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [IgnoreNamespace]
    [Imported]
    public sealed class TouchInfo {

        internal TouchInfo() {
        }

        [IntrinsicProperty]
        public int ClientX {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public int ClientY {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public int Identifier {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public int PageX {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public int PageY {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public int ScreenX {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public long ScreenY {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public Element Target {
            get {
                return null;
            }
        }
    }
}
