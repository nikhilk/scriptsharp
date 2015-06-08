// App.cs
//

using System;
using WebREPL;

[ScriptModule]
internal static class App {

    static App() {
        (new CommandHandler()).Run();
    }
}
