// HomePage.cs
//

using System;
using System.Collections.Generic;
using System.Html;
using System.Runtime.CompilerServices;
using jQueryApi;

namespace $safeprojectname$.Home
{
    [GlobalMethods]
    internal static class HomePage
    {
        static HomePage()
        {
            jQuery.OnDocumentReady(delegate() {
                // Add script that runs once the document is ready for being
                // consumed by script.
            });
        }
    }
}
