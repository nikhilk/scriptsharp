// GadgetSettingsEvent.cs
// Script#/Libraries/Windows
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Gadgets {

    /// <summary>
    /// Allows handling cancelation and closing of the gadget's settings dialog.
    /// </summary>
    [IgnoreNamespace]
    [Imported]
    public sealed class GadgetSettingsEvent {

        private GadgetSettingsEvent() {
        }

        [IntrinsicProperty]
        [PreserveCase]
        public GadgetSettingsDialogAction Action {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public bool Cancel {
            get {
                return false;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public bool Cancellable {
            get {
                return false;
            }
        }

        [IntrinsicProperty]
        public GadgetSettingsCloseAction CloseAction {
            get {
                return GadgetSettingsCloseAction.Cancel;
            }
        }
    }
}
