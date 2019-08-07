using System;
using System.Text;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace ExpressionTests {

    public class App {

        public void Test(int arg) {
            arg = Script.Or(arg, 10);
            arg = Script.Or(arg, 10, 100);
            string s = Script.Or(arg, 10).ToString(10);
            bool b = Script.Boolean(arg);

            int i;
            Action tick = delegate() {
                i = 10;
            };
            int cookie = Script.SetInterval(tick, 500);
            Script.ClearInterval(cookie);

            bool isNotSet = Script.IsNullOrUndefined(i);
            b = Script.IsNull(i);
            b = Script.IsUndefined(i);
            b = Script.IsValue(i);
            b = Script.IsNaN(0);
            b = Script.IsFinite(3);
            b = Script.IsTruthy(0);
            b = Script.IsTruthy(b);
            b = Script.IsTruthy(b && b);
            b = Script.IsFalsey(1);
            b = Script.IsFalsey(b && b);

            int addition = (int)Script.Eval("2 + 2");

            addition = (int)Script.Literal("2 + 2");
            addition = (int)Script.Literal("{0} + {1}", 2, 3);

            object g = Script.Global;
            object u = Script.Undefined;

            object coreModule = Script.Modules["ss"];
        }
    }
}
