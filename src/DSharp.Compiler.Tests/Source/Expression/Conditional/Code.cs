using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace ExpressionTests {

    public class App {

        public void Test(int arg) {
            bool b = (arg == 0) ? true : false;
            b = arg == 0 ? true : false;

            int n = (arg == 0) ? --arg : ++arg;
            n = (arg == 0) ? (b ? 10 : (arg - 1)) : 100;

            string s = (n > 50) ? "xyz" : "abc";

            int l = (s != null) ? s.Length : "Hello".Length;
        }
    }
}
