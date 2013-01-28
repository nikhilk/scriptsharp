// Page.cs
//

using System;
using KnockoutApi;
using Cellar;

[ScriptModule]
internal static class Page {

    static Page() {
        Knockout.ApplyBindings(new CellarApplication());
    }
}
