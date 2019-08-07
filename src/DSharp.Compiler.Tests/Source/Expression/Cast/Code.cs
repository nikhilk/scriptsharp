using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace ExpressionTests {

    public delegate void MyCallback();

    public class App {

        public void Test(int arg) {
            float f = arg / 2f;
            double d = 0.25;

            int i = (int)f;
            int j = (int)d;

            float f2 = (float)d;

            int a = 1;
            int b = 2;

            int n1 = a / b;
            int n2 = (int)(a / b);
            double d2 = a / b;

            Action action = (Action)delegate() {
            };
            Action secondAction = action as Action;
            if (action is Action) {
            }

            MyCallback cb = action as MyCallback;
            if (action is MyCallback) {
                cb = (MyCallback)action;
            }
            
            Action<bool> action2 = action as Action<bool>;
            if (action2 != null) {
            }
        }
    }
}
