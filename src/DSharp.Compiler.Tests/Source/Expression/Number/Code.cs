using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace ExpressionTests {

    public class App {

        public void Test(int arg) {
            int i = Number.ParseInt("5");
            float f = Number.ParseFloat("5.3");
            bool b1 = Number.IsNaN(0);
            bool b2 = Number.IsFinite(3);
        }
    }
}
