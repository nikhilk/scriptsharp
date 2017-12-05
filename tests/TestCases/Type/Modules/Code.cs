using System;
using System.Html;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

[ScriptModule]
internal static class Startup {

    static Startup() {
        Window.Alert("Hello Startup");
    }
}

namespace App {

#if INCLUDE_EXPORT
    public class Dummy { }
#endif

    [ScriptModule]
    internal static class Main {

        static Main() {
            Window.AddEventListener("load", delegate(ElementEvent e) {
                Window.Alert("Loaded");
            }, false);
        }
    }
}
