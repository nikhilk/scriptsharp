// ElementEvent.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [IgnoreNamespace]
    [ScriptImport]
    public class ElementEvent {

        internal ElementEvent() {
        }

        [ScriptProperty]
        public bool AltKey {
            get {
                return false;
            }
        }

        [ScriptProperty]
        public int Button {
            get {
                return 0;
            }
        }

        [ScriptProperty]
        public bool CancelBubble {
            get {
                return false;
            }
            set {
            }
        }

        [ScriptProperty]
        public bool CtrlKey {
            get {
                return false;
            }
        }

        [ScriptProperty]
        public Element CurrentTarget {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public DataTransfer DataTransfer {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public string Detail {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public Element FromElement {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public int KeyCode {
            get {
                return 0;
            }
        }

        [ScriptProperty]
        public bool MetaKey {
            get {
                return false;
            }
        }

        [ScriptProperty]
        public int OffsetX {
            get {
                return 0;
            }
        }

        [ScriptProperty]
        public int OffsetY {
            get {
                return 0;
            }
        }

        [ScriptProperty]
        public bool ReturnValue {
            get {
                return false;
            }
            set {
            }
        }

        [ScriptProperty]
        public bool ShiftKey {
            get {
                return false;
            }
        }

        [ScriptProperty]
        public Element SrcElement {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public Element Target {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public Date TimeStamp {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public Element ToElement {
            get {
                return null;
            }
        }

        [ScriptProperty]
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
