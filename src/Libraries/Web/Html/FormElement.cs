// FormElement.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class FormElement : Element {

        internal FormElement() {
        }

        [ScriptField]
        public string AcceptCharset {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public string Action {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public Element[] Elements {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public string EncType {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public string Encoding {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public int Length {
            get {
                return 0;
            }
        }

        [ScriptField]
        public string Name {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public string Method {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public string Target {
            get {
                return null;
            }
            set {
            }
        }

        public void Reset() {
        }

        public void Submit() {
        }
    }
}
