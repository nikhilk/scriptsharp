using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace StatementTests {

    public enum Mode { Foo = 0, Bar = 1 }

    public class App {

        public void Test(int arg, Mode m) {
            int i;

            switch (i) {
                case 0:
                    i = 0;
                    break;
                case 1:
                    i = 2;
                    break;
                case 2:
                    break;
                case 3: case 4:
                    i = 4;
                    break;
                default:
                    i = 5;
                    break;
            }

            switch (arg) {
                case 0:
                    i = 0;
                    break;
                case 1: default:
                    i = 2;
                    break;
            }

            switch (m) {
                case Mode.Foo:
                    break;
                case Mode.Bar:
                    break;
            }
        }
    }
}
