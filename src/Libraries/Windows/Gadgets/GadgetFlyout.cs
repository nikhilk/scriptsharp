// GadgetFlyout.cs
// Script#/Libraries/Windows
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace System.Gadgets {

    /// <summary>
    /// Represents the flyout associated with the gadget.
    /// </summary>
    [IgnoreNamespace]
    [Imported]
    public sealed class GadgetFlyout {

        private GadgetFlyout() {
        }

        [IntrinsicProperty]
        public DocumentInstance Document {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public string File {
            get {
                return null;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public Action OnHide {
            get {
                return null;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public Action OnShow {
            get {
                return null;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public bool Show {
            get {
                return false;
            }
            set {
            }
        }
    }
}
