using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace StatementTests {

    public class App {

        public int Test1(int arg) {
            return 0;
        }

        public int Test2(int arg) {
            return arg;
        }

        public void Test3(bool a) {
            if (a) {
                return;
            }

            int i;
            switch (i) {
                case 0:
                    return;
            }
        }

        public Dictionary<string, object> Test4() {
            return new Dictionary<string, object>();
        }
    }
}
