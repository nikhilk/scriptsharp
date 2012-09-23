using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace MemberTests {

    public enum Mode { A = 0, B = 1 };

    public class Test {
        public static readonly string Greeting = "Hello!";
        public const int MyNumber = 1;

        public const string DefaultValue = "aaa";
        private const string DefaultPrivateValue = "bbb";

        public static bool done;

        protected static int XYZ = 1;
        private static readonly object key = new object();

        private int _value;
        private uint _uintValue;
        private double _dblValue;
        private Mode _enumValue;
        private bool _boolValue;
        public string s;

        public Test() {
            _value = 2006;
            s = DefaultValue;
            s = DefaultPrivateValue;
            s = Test.DefaultValue;
        }
    }

    [ScriptObject]
    internal sealed class Point {
         public int x;
         public int y;

         public Point(int x, int y) {
             this.x = x;
             this.y = y;
         }
    }

    public class App {

        private Test _t = new Test();
        private int _i = 5;

        public void DoTest() {
            Test t = new Test();

            t.s = "World";
            int i = Test.MyNumber;

            Test.done = true;

            Point p = new Point(1, 10);
            p.x = p.y;
        }
    }
}
