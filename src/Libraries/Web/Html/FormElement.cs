// FormElement.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [IgnoreNamespace]
    [ScriptImport]
    public sealed class FormElement : Element {

        internal FormElement() {
        }

        [ScriptProperty]
        public string AcceptCharset {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptProperty]
        public string Action {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptProperty]
        public Element[] Elements {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptProperty]
        public string EncType {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptProperty]
        public string Encoding {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptProperty]
        public int Length {
            get {
                return 0;
            }
        }

        [ScriptProperty]
        public string Name {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptProperty]
        public string Method {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptProperty]
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
