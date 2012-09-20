using System;
using System.Collections;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace StatementTests {

    public class Set : IEnumerable {

        private int[] _items;

        public IEnumerator GetEnumerator() {
            return _items.GetEnumerator();
        }
    }

    public class App {

        public void Test(int arg) {
            int[] items = new int[] { 1, 2, 3 };
            int sum = 0;

            foreach (int i in items) {
                sum += i;
            }

            Dictionary d = new Dictionary();
            foreach (DictionaryEntry entry in d) {
                string s = entry.Key + " = " + entry.Value;
            }

            Set s = new Set();
            foreach (object o in s) {
                DoStuff(o);
            }

            foreach (DictionaryEntry entry in GetDictionary()) {
                string s = entry.Key + " = " + entry.Value;
            }
        }

        private void DoStuff(object o) {
            foreach (DictionaryEntry entry in Dictionary.GetDictionary(o)) {
            }
        }

        private Dictionary GetDictionary() {
            return null;
        }
    }
}
