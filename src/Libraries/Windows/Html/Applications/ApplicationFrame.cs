// ApplicationFrame.cs
// Script#/Libraries/Windows
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace System.Html.Applications {

    [IgnoreNamespace]
    [Imported]
    public static class ApplicationFrame {

        [IntrinsicProperty]
        public static string ApplicationName {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public static ApplicationBorder Border {
            get {
                return ApplicationBorder.Thick;
            }
        }

        [IntrinsicProperty]
        public static ApplicationBorderStyle BorderStyle {
            get {
                return ApplicationBorderStyle.Normal;
            }
        }

        [IntrinsicProperty]
        public static YesNoState Caption {
            get {
                return YesNoState.Yes;
            }
        }

        [IntrinsicProperty]
        public static string CommandLine {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public static YesNoState ContextMenu {
            get {
                return YesNoState.Yes;
            }
        }

        [IntrinsicProperty]
        public static string Icon {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public static YesNoState InnerBorder {
            get {
                return YesNoState.Yes;
            }
        }

        [IntrinsicProperty]
        public static YesNoState MaximizeButton {
            get {
                return YesNoState.Yes;
            }
        }

        [IntrinsicProperty]
        public static YesNoState MinimizeButton {
            get {
                return YesNoState.Yes;
            }
        }

        [IntrinsicProperty]
        public static YesNoState Navigable {
            get {
                return YesNoState.Yes;
            }
        }

        [IntrinsicProperty]
        public static YesNoState Scroll {
            get {
                return YesNoState.Yes;
            }
        }

        [IntrinsicProperty]
        public static YesNoState ScrollFlat {
            get {
                return YesNoState.Yes;
            }
        }

        [IntrinsicProperty]
        public static YesNoState Selection {
            get {
                return YesNoState.Yes;
            }
        }

        [IntrinsicProperty]
        public static YesNoState ShowInTaskBar {
            get {
                return YesNoState.Yes;
            }
        }

        [IntrinsicProperty]
        public static YesNoState SingleInstance {
            get {
                return YesNoState.Yes;
            }
        }

        [IntrinsicProperty]
        public static YesNoState SysMenu {
            get {
                return YesNoState.Yes;
            }
        }

        [IntrinsicProperty]
        public static string Version {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public static ApplicationWindowState WindowState {
            get {
                return ApplicationWindowState.Normal;
            }
        }
    }
}
