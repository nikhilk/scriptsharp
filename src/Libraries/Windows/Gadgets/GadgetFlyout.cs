// GadgetFlyout.cs
// Script#/Libraries/Windows
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
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
