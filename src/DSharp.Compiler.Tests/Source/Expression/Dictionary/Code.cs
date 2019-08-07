using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace ExpressionTests {

    public class App {

        public IDictionary GetData() {
            return null;
        }

        public IDictionary<string, int> GetData2() {
            return null;
        }

        public void Test(int arg) {
            Dictionary<string, object> dictionary1 = new Dictionary<string, object>();
        }

        public void Test2(int arg) {
            Dictionary<string, object> dictionary1 = new Dictionary<string, object>();
            string key = "blah";
            int c = dictionary1.Keys.Count;

            int c2 = GetData().Keys.Count;

            dictionary1.Remove("aaa");
            dictionary1.Remove("Proxy-Connection");
            dictionary1.Remove(key);

            dictionary1.Clear();

            dictionary1["asd"] = 3;
            object val = dictionary1["asd"];

            dictionary1.Add("hello", "bye");

            dictionary1.ContainsKey("asd");
            dictionary1.Contains("asd");

            foreach (KeyValuePair<string, object> pair in dictionary1)
            {
                string myKey = pair.Key;
                object myValue = pair.Value;
            }

            ICollection<string> keys = dictionary1.Keys;
            ICollection<object> values = dictionary1.Values;
        }

        public void Test3(int arg) {
            Dictionary<string, int> dictionary1 = new Dictionary<string, int>();
            string key = "blah";
            int c = dictionary1.Keys.Count;

            int c2 = GetData2().Keys.Count;

            bool b = dictionary1.ContainsKey("aaa");

            dictionary1.Remove("aaa");
            dictionary1.Remove("Proxy-Connection");
            dictionary1.Remove(key);

            dictionary1.Clear();
            
            string[] keys = dictionary1.Keys;
        }

        public void Test4(int arg) {
            Dictionary<int, string> d1 = new Dictionary<int, string>();
            d1[1] = d1[arg] = "aaa";
            d1.Remove(1);
            d1.Remove(arg);
        }
    }
}
