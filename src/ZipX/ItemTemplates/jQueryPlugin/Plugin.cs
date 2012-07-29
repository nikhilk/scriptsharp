// $safeitemrootname$.cs
//

using System;
using System.Collections.Generic;
using System.Html;
using System.Runtime.CompilerServices;
using jQueryApi;

[Mixin("$.fn")]
public static class $safeitemrootname$Plugin
{
    public static jQueryObject $safeitemrootname$($safeitemrootname$Options customOptions)
    {
        $safeitemrootname$Options defaultOptions =
            new $safeitemrootname$Options("myOption", 0
                                          /* name/value pairs corresponding to default options */);
                                          
        $safeitemrootname$Options options =
            jQuery.ExtendObject<$safeitemrootname$Options>(new $safeitemrootname$Options(), defaultOptions, customOptions);

        return jQuery.Current.Each(delegate (int i, Element element) {
            // TODO: Consume the matched elements
        });
    }
}

[Imported]
[ScriptName("Object")]
public sealed class $safeitemrootname$Options
{
    // TODO: Replace with fields corresponding to options for the plugin
    public int myOption;

    public $safeitemrootname$Options() {
    }

    public $safeitemrootname$Options(params object[] nameValuePairs) {
    }
}

#region Script# Support
[Imported]
public sealed class $safeitemrootname$Object : jQueryObject
{
    public jQueryObject $safeitemrootname$() {
        return null;
    }

    public jQueryObject $safeitemrootname$($safeitemrootname$Options options) {
        return null;
    }
}
#endregion
