// AnchorElement.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [IgnoreNamespace]
    [ScriptImport]
    public sealed class AnchorElement : Element {

        private AnchorElement() {
        }

        [ScriptProperty]
        public string Href {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptProperty]
        public string Rel {
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
        
        [ScriptProperty]
        public string Download {
            get {
                return null;
            }
            set {
            }
        }
    }
}
