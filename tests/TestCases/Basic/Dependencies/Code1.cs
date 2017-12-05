using System;
using Library1;
using Library2;
using Library3;

[assembly: ScriptAssembly("test")]

namespace BasicTests {

    public class App {

        public App() {
            Component1 c1 = new Component1();
            Component1 c2 = new Component2();
        }
    }
}
