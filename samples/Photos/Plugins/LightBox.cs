// Isotope.cs
//

using System;
using System.Html;
using System.Runtime.CompilerServices;
using jQueryApi;

namespace jQueryApi.LightBox {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptDependency("jqueryLightBox")]
    public sealed class jQueryLightBoxObject : jQueryObject {

        private jQueryLightBoxObject() {
        }

        public jQueryObject LightBox() {
            return null;
        }
    }
}
