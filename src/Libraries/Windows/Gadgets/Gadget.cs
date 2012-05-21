// Gadget.cs
// Script#/Libraries/Windows
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace System.Gadgets {

    /// <summary>
    /// Represents the current gadget.
    /// </summary>
    [IgnoreNamespace]
    [Imported]
    public static class Gadget {

        [IntrinsicProperty]
        public static string Background {
            get {
                return null;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public static DocumentInstance Document {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public static bool Docked {
            get {
                return false;
            }
            set {
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public static GadgetFlyout Flyout {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public static string Name {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public static Action OnDock {
            get {
                return null;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public static GadgetSettingsDialogCallback OnSettingsClosed {
            get {
                return null;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public static GadgetSettingsDialogCallback OnSettingsClosing {
            get {
                return null;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public static Action OnShowSettings {
            get {
                return null;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public static Action OnUndock {
            get {
                return null;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public static int Opacity {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public static string Path {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public static string PlatformVersion {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public static GadgetSettings Settings {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public static string SettingsUI {
            get {
                return null;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public static string Version {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public static bool Visible {
            get {
                return false;
            }
        }

        [IntrinsicProperty]
        public static Action VisibilityChanged {
            get {
                return null;
            }
            set {
            }
        }

        public static void BeginTransition() {
        }

        public static void Close() {
        }

        public static void EndTransition(GadgetTransition transition, double seconds) {
        }
    }
}
