// LinkElement.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class LinkElement : Element {

        private LinkElement() {
        }

        [ScriptField]
        public string Href {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public string Media {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public string Rel {
            get {
                return null;
            }
            set {
            }
        }
    }
}
