// VisualFilterCollection.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.Media.Filters {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class VisualFilterCollection {

        private VisualFilterCollection() {
        }

        [ScriptField]
        public int Length {
            get {
                return 0;
            }
        }

        [ScriptField]
        public VisualFilter this[int index] {
            get {
                return null;
            }
        }
    }
}
