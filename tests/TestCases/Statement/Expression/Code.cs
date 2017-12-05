using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace StatementTests {

    public class App {

        public void Test(int arg) {
            string x;

            arg = x.Length;
            arg++;
            x = arg.ToString();
        }
    }
}
