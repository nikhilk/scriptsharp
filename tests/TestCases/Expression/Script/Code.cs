using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace ExpressionTests {

    public class App {

        public void Test(int arg) {
            arg = Script.Value(arg, 10);
            arg = Script.Value(arg, 10, 100);
            string s = Script.Value(arg, 10).ToString(10);
            bool b = Script.Boolean(arg);

            StringBuilder sb = (StringBuilder)Script.CreateInstance(typeof(StringBuilder));
            sb = (StringBuilder)Script.CreateInstance(typeof(StringBuilder), "aaa");

            int i;
            Action tick = delegate() {
                i = 10;
            };
            int cookie = Script.SetInterval(tick, 500);
            Script.ClearInterval(cookie);

            bool isSet = Script.IsNullOrUndefined(i) == false;

            int addition = (int)Script.Eval("2 + 2");

            addition = (int)Script.Literal("2 + 2");
            addition = (int)Script.Literal("{0} + {1}", 2, 3);

            object g = Script.Global;
        }
    }
}
