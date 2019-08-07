using System;
using Library1;
using Library2;
using Library3;

[assembly: ScriptAssembly("test")]

namespace BasicTests {

    public class App {

        public App() {
            Component1 c1 = new Component1();
            Component2 c2 = new Component2();
            Component3 c3 = new Component3();
            Component4 c4 = new Component4();
        }
    }
}
