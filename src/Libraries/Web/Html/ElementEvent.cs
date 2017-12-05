// ElementEvent.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public class ElementEvent {

        internal ElementEvent() {
        }

        [ScriptField]
        public bool AltKey {
            get {
                return false;
            }
        }

        [ScriptField]
        public int Button {
            get {
                return 0;
            }
        }

        [ScriptField]
        public bool CancelBubble {
            get {
                return false;
            }
            set {
            }
        }

        [ScriptField]
        public int ClientX {
            get {
                return 0;
            }
        }

        [ScriptField]
        public int ClientY {
            get {
                return 0;
            }
        }

        [ScriptField]
        public bool CtrlKey {
            get {
                return false;
            }
        }

        [ScriptField]
        public Element CurrentTarget {
            get {
                return null;
            }
        }

        [ScriptField]
        public DataTransfer DataTransfer {
            get {
                return null;
            }
        }

        [ScriptField]
        public string Detail {
            get {
                return null;
            }
        }

        [ScriptField]
        public Element FromElement {
            get {
                return null;
            }
        }

        [ScriptField]
        public int KeyCode {
            get {
                return 0;
            }
        }

        [ScriptField]
        public bool MetaKey {
            get {
                return false;
            }
        }

        [ScriptField]
        public int OffsetX {
            get {
                return 0;
            }
        }

        [ScriptField]
        public int OffsetY {
            get {
                return 0;
            }
        }

        [ScriptField]
        public int PageX {
            get {
                return 0;
            }
        }

        [ScriptField]
        public int PageY {
            get {
                return 0;
            }
        }

        [ScriptField]
        public bool ReturnValue {
            get {
                return false;
            }
            set {
            }
        }

        [ScriptField]
        public int ScreenX {
            get {
                return 0;
            }
        }

        [ScriptField]
        public int ScreenY {
            get {
                return 0;
            }
        }

        [ScriptField]
        public bool ShiftKey {
            get {
                return false;
            }
        }

        [ScriptField]
        public Element SrcElement {
            get {
                return null;
            }
        }

        [ScriptField]
        public Element Target {
            get {
                return null;
            }
        }

        [ScriptField]
        public Date TimeStamp {
            get {
                return null;
            }
        }

        [ScriptField]
        public Element ToElement {
            get {
                return null;
            }
        }

        [ScriptField]
        public string Type {
            get {
                return null;
            }
        }

        [ScriptField]
        public bool Bubbles
        {
            get
            {
                return false;
            }
        }

        [ScriptField]
        public bool Cancelable
        {
            get
            {
                return false;
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
