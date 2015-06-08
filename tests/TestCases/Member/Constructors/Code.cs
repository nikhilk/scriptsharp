using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace MemberTests {

    public class MyClass {

        private int _value;

        public MyClass() {
            _value = 1;
        }
    }

    public class MyClass2 {

        private static string x;

        static MyClass() {
            x = "Hello";
        }
    }

    public class MyClass3 {

        public static MyClass c;

        static MyClass() {
            c = new MyClass();
        }

        public MyClass3(int arg, int arg2) {
        }
    }

    public class MyClass4 : MyClass3 {

        public MyClass4(int arg, int arg2, int arg3) : base(arg, arg2) {
        }
    }
}
