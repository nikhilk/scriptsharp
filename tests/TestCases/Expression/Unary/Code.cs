using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace ExpressionTests {

    public class Data {
        private int _value;

        public int Value {
            get { return _value; }
            set { _value = value; }
        }
    }

    public class App {

        public void Test(int arg) {
            int xyz = ~arg;
            bool f = (arg == 0);
            f = !f;

            int m = arg;
            m++;
            int n = ++m;

            m--;
            n = --m;

            n = -m;
            n = +m;
            n = +1;
            n = 1 + (+2);

            string s = (!f).ToString();
            float num = 1.01;
            s = (~num).ToExponential();

            Data d = new Data();
            d.Value++;
            ++d.Value;
        }
    }
}
