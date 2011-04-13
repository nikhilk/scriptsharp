// GadgetSettingsEvent.cs
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
