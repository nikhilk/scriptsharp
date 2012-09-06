using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]
[assembly: ScriptNamespace("test")]

namespace ExpressionTests {

    public class App {

        public void Test(int arg) {
            arg = Script.Value(arg, 10);
            arg = Script.Value(arg, 10, 100);
            string s = Script.Value(arg, 10).Format("{0}");
            bool b = Script.Boolean(arg);
        }
    }
}
