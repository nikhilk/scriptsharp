using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace TypeTests {

    public class App1 : IEnumerable {
        public IEnumerator GetEnumerator() {
            return null;
        }
    }

    public class App {

        public void Test1(int arg) {
        }
        
        public void Test(int arg) {
            Array a;
            List<int> b;
            string[] s = new string[5];
            IEnumerable a1 = a.GetEnumerator();
            a1 = b.GetEnumerator();
            a1 = s.GetEnumerator();
            foreach (string str in s) {
                string s1 = str;
            }
            
            App1 app1;
            foreach (string str in app1) {
                string s1 = str;
            }
        }
    }
}
