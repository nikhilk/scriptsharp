using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace ExpressionTests {

    public class App {

        public void Test(int arg) {
            string x;

            int i = x.Length;
            while (i >= 0) {
                string x2 = x.Substring(0);

                for (int j = 0; j < 1; j++) {
                }
                string j = x2;
                i = j.Length;
            }

            while (i >= 0) {
                string x2 = "...";
            }
        }

        public void Test2(int arg1, int arg2) {
            arg2 = arg1;
        }
    }
}
