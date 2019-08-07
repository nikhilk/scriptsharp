using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace ExpressionTests {

    public class App {

        public void Test(int arg) {
            int i;
            int j;
            bool f;
            object o;
            string s;

            if (i == 0) {
            }
            if (i != 0) {
            }
            if (i == 1) {
            }
            if (i == j) {
            }
            if (s.Length != 0) {
            }
            if (s == "") {
            }
            if (s != "") {
            }
            if (s == String.Empty) {
            }
            if (s != String.Empty) {
            }

            if (f == true) {
            }
            if (f != true) {
            }
            if (f == false) {
            }
            if (f != false) {
            }
            if (f == f) {
            }

            if (o == null) {
            }
            if (o != null) {
            }

            if ((s + s) != null) {
            }
            if ((s + s) == null) {
            }
            
            if (i % 2 != 0) {
            }
            if (i % 2 == 0) {
            }
            if ((i % 2) == 0) {
            }
            if (i++ == 0) {
            }
        }
    }
}
