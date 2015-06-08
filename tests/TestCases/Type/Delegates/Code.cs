using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace TypeTests {

    public class EventArgs {
    }

    public delegate void Foo();

    public delegate void EventHandler(object sender, EventArgs e);
}
