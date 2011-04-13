// Sidebar.cs
// Script#/Libraries/Windows
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
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
