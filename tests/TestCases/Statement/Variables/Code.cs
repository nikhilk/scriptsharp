using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace StatementTests {

    public class App {

        public void Test() {
            int i = 0;
            bool b = true;
            int x = i + 10;
            int y, z;

            int a = 1, c, d, e = c;
        }

        public void Test2(int arg) {
            int a = 1;
            int b = arg;

            while (a < b) {
                int x = a - b;
                a++;
            }

            while (a >= b) {
                string x = "Hello World";
                int foo = x.Length;
            }
        }

        public void Test3(int arg1, int arg2) {
            int value = arg1 + arg2;
        }
    }
}
