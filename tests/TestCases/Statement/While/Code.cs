using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace StatementTests {

    public class App {

        public void Test(int arg) {
            int i;
            while (i < arg) {
            }

            while (i < arg) {
                i++;
            }

            while (arg == i) {
                break;
            }

            do {
               i--;
            } while (i > 0);

            do {
            } while (i != 0);
        }
    }
}
