// VisualFilter.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.Media.Filters {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public class VisualFilter {

        internal VisualFilter() {
        }

        [ScriptField]
        public bool Enabled {
            get {
                return false;
            }
            set {
            }
        }
    }
}
