// BingMapsApplication.cs
//

using System;
using System.Collections;
using System.Html;
using System.Runtime.CompilerServices;

namespace BingMapsApp {

    internal static class BingMapsApplication {

        static BingMapsApplication() {
            Window.AddEventListener("load", delegate(ElementEvent e) {
                BingMapsShell shell = new BingMapsShell();
                shell.Run();
            }, /* useCapture */ false);
        }
    }
}
