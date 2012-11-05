// $safeitemname$Plugin.cs
//

using System;
using System.Collections.Generic;
using System.Html;
using System.Runtime.CompilerServices;
using jQueryApi;

[ScriptExtension("$.fn")]
internal static class $safeitemname$Plugin {

    public static jQueryObject $safeitemname$($safeitemname$Options customOptions) {

        $safeitemname$Options defaultOptions =
            new $safeitemname$Options("myOption", 0
                                          /* name/value pairs corresponding to default options */);
                                          
        $safeitemname$Options options =
            jQuery.ExtendObject<$safeitemname$Options>(new $safeitemname$Options(), defaultOptions, customOptions);

        return jQuery.Current.Each(delegate (int i, Element element) {
            // TODO: Consume the matched elements
        });
    }
}

[ScriptImport]
[ScriptName("Object")]
public sealed class $safeitemname$Options {

    // TODO: Replace with fields corresponding to options for the plugin
    public int myOption;

    public $safeitemname$Options() {
    }

    public $safeitemname$Options(params object[] nameValuePairs) {
    }
}

#region Script# Support
// This class allows calling into the plugin from an application or another plugin.
[ScriptImport]
public sealed class $safeitemname$Object : jQueryObject {

    private $safeitemname$Object() {
    }

    public jQueryObject $safeitemname$() {
        return null;
    }

    public jQueryObject $safeitemname$($safeitemname$Options options) {
        return null;
    }
}
#endregion
