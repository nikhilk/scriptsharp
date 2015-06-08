using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace StatementTests {

    public class App {

        public void Test(int arg) {
            for (int i = 0; i < 10; i++) {
            }

            int x = 10;
            int y = 100;
            for (; x < y; x++) {
            }

            for (; x < y; ) {
            }

            for (int j = 1, k = 1; ; j++, k--) {
            }

            for (x = 1; x < 100; ) {
            }

            for (x = arg; x < 100; x++) {
            }

            for (x = 1; x < 2; x++) {
                int z = x;
            }
        }
    }
}
