// SidebarTimeZoneCollection.cs
// Script#/Libraries/Windows
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Gadgets {

    [IgnoreNamespace]
    [Imported]
    public sealed class SidebarTimeZoneCollection {

        private SidebarTimeZoneCollection() {
        }

        [IntrinsicProperty]
        public int Count {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public SidebarTimeZone this[int index] {
            get {
                return null;
            }
        }
    }
}
