// ElementEvent.cs
// Script#/Libraries/Web
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [IgnoreNamespace]
    [Imported]
    public class ElementEvent {

        internal ElementEvent() {
        }

        [IntrinsicProperty]
        public bool AltKey {
            get {
                return false;
            }
        }

        [IntrinsicProperty]
        public int Button {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public bool CancelBubble {
            get {
                return false;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public bool CtrlKey {
            get {
                return false;
            }
        }

        [IntrinsicProperty]
        public Element CurrentTarget {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public DataTransfer DataTransfer {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public string Detail {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public Element FromElement {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public int KeyCode {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public bool MetaKey {
            get {
                return false;
            }
        }

        [IntrinsicProperty]
        public int OffsetX {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public int OffsetY {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public bool ReturnValue {
            get {
                return false;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public bool ShiftKey {
            get {
                return false;
            }
        }

        [IntrinsicProperty]
        public Element SrcElement {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public Element Target {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public Date TimeStamp {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public Element ToElement {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public string Type {
            get {
                return null;
            }
        }

        public void PreventDefault() {
        }

        public void StopImmediatePropagation() {
        }

        public void StopPropagation() {
        }
    }
}
