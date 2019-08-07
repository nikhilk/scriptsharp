using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace ExpressionTests {

    public class App {

        public void Test(int arg) {
            int i = 0;
            i = -1;
            i = 1;
            i = 1000000;

            long n = 10000L;
            float f = 1f;
            double d = 1.01;
            double d2 = .5;
            double d3 = -.5;

            bool b = true;
            b = false;

            char ch = '\n';
            ch = 'a';
            string s = "Hello";
            string s2 = "Hello\r\n";
            string s3 = "abc" + "123";
            string s4 = "abc\"def'xyz";
            string s5 = "abc\u00A9";
            string s6 = "abc'xyz";
            string s7 = "abc\"xyz";

            Type t = typeof(App);
            Type t2 = typeof(Int32);
            Type t3 = typeof(int);
            Type t4 = typeof(Dictionary<object, object>);

            int[] items = new int[] { 1, 2, 3 };
        }
    }
}
