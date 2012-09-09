using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace ExpressionTests {

    public class App {

        private int Foo { get { return 0; } }

        public void Test(object x) {
            Type t = x.GetType();
            Type t2 = x.ToString().GetType();
            Type t3 = Foo.GetType();
        }
    }
}
