using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace ExpressionTests {

    public class App {

        private const string ScriptTemplate = "alert({0} + {1})";

        public void Test(int arg) {
            Script.Literal("arg + 1");

            int i = (int)Script.Literal("arg + 1");
            int j = (int)Script.Literal("{0} + 1", arg);
            int k = (int)Script.Literal("{0} + {1}", arg, 1);

            int a = 10;

            Script.Literal(ScriptTemplate, a, a);
        }
    }
}
