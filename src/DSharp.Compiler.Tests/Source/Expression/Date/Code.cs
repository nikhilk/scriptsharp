using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace ExpressionTests {

    public class App {

        public void Equality() {
            Date d1 = null;
            Date d2 = null;

            if (d1 == d2) {
            }
            if (d1 != d2) {
            }

            if (d1 == Date.Now) {
            }
            if (d1 != new Date()) {
            }

            object o;
            if (d1 == o) {
            }
            if (d1 != o) {
            }
        }
    }
}
