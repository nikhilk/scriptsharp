// Isotope.cs
//

using System;
using System.Html;
using System.Runtime.CompilerServices;
using jQueryApi;

namespace jQueryApi.Isotope {

    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum IsotopeLayout {

        Masonry
    }

    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class IsotopeOptions : Record {

        public IsotopeLayout LayoutMode;

        public IsotopeOptions() {
        }

        public IsotopeOptions(params object[] nameValuePairs) {
        }
    }

    [Imported]
    [IgnoreNamespace]
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
