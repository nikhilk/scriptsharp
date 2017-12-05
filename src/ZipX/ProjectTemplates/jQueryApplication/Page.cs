// Page.cs
//

using System;
using System.Collections.Generic;
using System.Html;
using jQueryApi;

[ScriptModule]
internal static class Page {

    static Page() {
        jQuery.OnDocumentReady(delegate() {
            // TODO: Add script that runs once the document is ready for being
            //       consumed by script.
            //       You can also add other classes comprising your application
            //       to the project.
        });
    }
}
