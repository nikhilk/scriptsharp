using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace ExpressionTests {

    public class App {

        public void Test(int arg) {
            string s = "Hello";
            string s2;

            s2 = s.Escape();
            s = s2.Unescape();
            s2 = s.EncodeUri();
            s = s2.DecodeUri();
            s2 = s.EncodeUriComponent();
            s = s2.DecodeUriComponent();
            s = s.ToUpper();
            s = s.ToLower();
        }
    }
}
