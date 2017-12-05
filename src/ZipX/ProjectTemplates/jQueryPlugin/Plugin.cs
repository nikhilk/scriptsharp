// $safeprojectname$Plugin.cs
//

using System;
using System.Collections.Generic;
using System.Html;
using System.Runtime.CompilerServices;
using jQueryApi;

[ScriptExtension("$.fn")]
internal static class $safeprojectname$Plugin {

    public static jQueryObject $safeprojectname$($safeprojectname$Options customOptions) {
        $safeprojectname$Options defaultOptions =
            new $safeprojectname$Options("myOption", 0
                                         /* name/value pairs corresponding to default options */);

        $safeprojectname$Options options =
            jQuery.ExtendObject<$safeprojectname$Options>(new $safeprojectname$Options(), defaultOptions, customOptions);

        return jQuery.Current.Each(delegate (int i, Element element) {
            // TODO: Consume the matched elements
        });
    }
}

[ScriptImport]
[ScriptName("Object")]
public sealed class $safeprojectname$Options {

    // TODO: Replace with fields corresponding to options for the plugin
    public int myOption;

    public $safeprojectname$Options() {
    }

    public $safeprojectname$Options(params object[] nameValuePairs) {
    }
}

#region Script# Support
// This class allows calling into the plugin from an application or another plugin.
[ScriptImport]
public sealed class $safeprojectname$Object : jQueryObject {

    private $safeprojectname$Object() {
    }

    public $safeprojectname$Object $safeprojectname$() {
        return null;
    }

    public $safeprojectname$Object $safeprojectname$($safeprojectname$Options options) {
        return null;
    }
}
#endregion
