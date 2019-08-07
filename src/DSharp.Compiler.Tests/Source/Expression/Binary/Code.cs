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

        public bool Flag {
            get { return true; }
            set { }
        }

        public static bool StaticFlag = false;
    }

    public class App {
    
        private const int CValue = 100;

        private int Foo { get { return 0; } set { } }
        private int Bar { get { return 0; } set { } }

        public Data Data { get { return new Data(); } set { } }

        public bool Flag1 { get { return Data.Flag; } }
        public bool Flag2 { get { return Data.StaticFlag; } }

        public void Test(int arg1, int arg2) {
            int sum = arg1 + arg2;
            sum += arg2 * -1;
            sum = arg1 - arg2;
            sum = arg1 * arg2;
            sum = arg1 / arg2;
            sum = arg1 ^ arg2;

            sum = arg1 >> 2;
            sum *= arg2;
            sum ^= arg2;

            float f = arg1;
            string s = (f + 1).ToExponential();

            int len = (10 + s).Length;

            bool b = (f < 10);

            sum = arg1 + (arg2 + 1) * 10;
            sum = arg1 + (arg2 + ~arg1) * (arg1 - 10);

            bool b2 = sum is int;

            object o = b as IDisposable;

            Foo += 10;
            Foo -= Bar;

            sum = sum << 1;
            sum <<= 1;

            uint xyz;
            uint abc;

            abc = xyz << 1;
            abc = xyz >> 2;
            abc <<= 1;
            xyz >>= 1;

            Data d = new Data();
            d.Value += 5;
            d.Flag |= true;

            object o1 = null ?? new object();
            
            string s2 = 10.ToString();
            s2 = CValue.ToString();
            s2 = true.ToString();
            s2 = 10.1.ToString();
            s2 = "aaa".ToString();
        }

        public void BitwiseBooleans() {
            bool a = true & false;
            bool b = true | false;
            bool c = true ^ false;
            a &= true;
            b |= true;
            c ^= true;
            a |= a || a;

            Data d = new Data();
            d.Flag &= true;
            d.Flag |= true;
            d.Flag ^= true;
        }
    }
}
