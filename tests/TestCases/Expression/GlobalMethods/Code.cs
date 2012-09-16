using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace ExpressionTests {

    public class App {

        public void Test(int arg) {
            Script.Eval("[ 1, 2 ]");
            Util.Foo();
            Script.SetTimeout(Util.Foo, 0);
        }
    }

    [ScriptExtension("$global")]
    public static class Util {

        public static void Foo() {
        }
    }
}
