// HelloPage.cs
//

using System;
using System.Collections.Generic;
using System.Html;
using KnockoutApi;
using App;

[ScriptModule]
internal static class HelloPage {

    static HelloPage() {
        Knockout.ApplyBindings(new AppModel());
    }
}
