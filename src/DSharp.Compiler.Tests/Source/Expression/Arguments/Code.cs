using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace ExpressionTests {

    public class App {

        public void Test(int arg) {
            int count = Arguments.Length;
            int value = (int)Arguments.GetArgument(0);
            object[] items = Arguments.ToArray();
        }
    }
}
