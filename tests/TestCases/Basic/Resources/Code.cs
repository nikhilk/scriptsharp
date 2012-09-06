using System;
using System.Runtime.CompilerServices;
using Resources;

[assembly: ScriptAssembly("test")]
[assembly: ScriptNamespace("test")]

namespace BasicTests {

    public class App {

        public App() {
            string s1 = Strings1.String1;
        }
    }
}
