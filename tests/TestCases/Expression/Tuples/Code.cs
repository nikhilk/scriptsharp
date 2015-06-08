using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace ExpressionTests {

    public class App {

        public void Test(int arg) {
            Tuple<int, int> t1 = new Tuple<int, int>();
            Tuple<int, int> t2 = new Tuple<int, int>(1, 2);

            Tuple<int, int, string> t3 = new Tuple<int, int, string>();
            Tuple<int, int, string> t4 = new Tuple<int, int, string>(1, 22, "333");
        }
    }
}
