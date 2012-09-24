// Isotope.cs
//

using System;
using System.Html;
using System.Runtime.CompilerServices;
using jQueryApi;

namespace jQueryApi.Isotope {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptConstants(UseNames = true)]
    public enum IsotopeLayout {

        Masonry
    }

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Object")]
    public sealed class IsotopeOptions {

        public IsotopeLayout LayoutMode;

        public IsotopeOptions() {
        }

        public IsotopeOptions(params object[] nameValuePairs) {
        }
    }

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptDependency("jqueryIsotope")]
    public sealed class jQueryIsotopeObject : jQueryObject {

        private jQueryIsotopeObject() {
        }

        public jQueryObject Isotope() {
            return null;
        }

        public jQueryObject Isotope(IsotopeOptions options) {
            return null;
        }
    }
}
