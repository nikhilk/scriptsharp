using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]
[assembly: ScriptNamespace("test")]

namespace ValidationTests {

    public class App {

        public void Test(int arg) {
            int a = 10;
            string scriptTemplate = "alert({0} + {1})";
            
            Script.Literal(scriptTemplate, a, a);
        }
    }
}
