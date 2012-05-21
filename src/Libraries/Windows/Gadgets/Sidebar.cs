// Sidebar.cs
// Script#/Libraries/Windows
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Gadgets {

    /// <summary>
    /// Represents the sidebar behavior associated with the gadget.
    /// </summary>
    [IgnoreNamespace]
    [Imported]
    public static class Sidebar {

        [IntrinsicProperty]
        public static SidebarDockSide DockSide {
            get {
                return SidebarDockSide.Left;
            }
        }

        [IntrinsicProperty]
        public static Action OnDockSideChanged {
            get {
                return null;
            }
            set {
            }
        }
    }
}
