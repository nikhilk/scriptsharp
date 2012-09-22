using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace ExpressionTests {

    public class App {

        public void Test(int arg) {
            ArrayList items = new ArrayList();
            items.Add(1);
            items.AddRange(1, 2, 3);

            List<int> numbers = new List<int>();
            numbers.Add(1);
            numbers.AddRange(1, 2, 3);
        }
    }
}
