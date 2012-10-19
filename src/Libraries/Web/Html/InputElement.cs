// InputElement.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public class InputElement : Element {

        protected internal InputElement() {
        }

        [ScriptField]
        public string DefaultValue {
            get {
                return null;
            }
        }

        [ScriptField]
        public FormElement Form {
            get {
                return null;
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
        public string Type {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public string Value {
            get {
                return null;
            }
            set {
            }
        }

        public void Select() {
        }
    }
}
