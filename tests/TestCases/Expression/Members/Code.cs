using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace ExpressionTests {

    enum Mode { A = 0, B = 1 }

    public interface IFoo {
        void Bar();
    }

    public class BApp {
        protected const int MyConstant = 3;
    }

    public class App : BApp {

        protected const int MyConstant2 = 3;
        private static int MyDefault = 1;
        protected static int MyDefault2 = 2;

        private int _value;
        protected int _value2;

        public int XYZ {
            get { return 1; }
            set { }
        }

        public void Test(int arg) {
            string s = String.Empty;
            int n = s.Length;

            int n2 = Number.MaxValue;
            Mode m = Mode.A;

            n = XYZ;
            n = this.XYZ;

            XYZ = n;
            this.XYZ = n;

            App a;
            n = a.XYZ;
            a.XYZ = n;

            n = _value;
            n = this._value;

            _value = n;
            this._value = n;

            n = MyDefault;
            n = App.MyDefault;
            n = MyConstant;
            n = App.MyConstant;
            n = BApp.MyConstant;
            n = MyConstant2;
            n = App.MyConstant2;
        }
    }

    public class DApp : App {

        public void Test2() {
            int n = XYZ;
            n = this.XYZ;
            n = base.XYZ;

            XYZ = n;
            this.XYZ = n;
            base.XYZ = n;

            _value2 = n;
            this._value2 = n;
            base._value2 = n;

            n = MyDefault2;
            n = App.MyDefault2;

            n = MyConstant;
            n = App.MyConstant;
            n = BApp.MyConstant;
            n = DApp.MyConstant;
            n = MyConstant2;
            n = DApp.MyConstant2;
        }

        public void Test3() {
            int[] i = new int[] { 1, 2 };
            i[0] = 1;
            i[1] = i[0];
            i[i[0]] = 20;
        }

        public void Test4(IFoo foo) {
            foo.Bar();
        }
    }
}
