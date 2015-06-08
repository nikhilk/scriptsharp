// FishTankApplication.cs
//

using System;
using System.Collections;
using System.Html;
using FishTankApp;

[ScriptModule]
internal static class FishTankApplication {

    static FishTankApplication() {
        Window.AddEventListener("load", delegate(ElementEvent e) {
            FishTank fishtank = new FishTank();
            fishtank.Run();
        }, /* useCapture */ false);
    }
}
