// MapApplication.cs
//

using System;
using System.Html;

namespace MapDemo {

    internal static class MapApplication {

        static MapApplication() {
            Window.AddEventListener("load", delegate(ElementEvent e) {
                MapPage page = new MapPage();
                page.Run();
            }, /* useCapture */ false);
        }
    }
}
