using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace ExpressionTests {

    public class App {

        public void TestDictionary(int arg) {
            Dictionary<string, object> dictionary1 = new Dictionary<string, object>();
            string key = "blah";
            int c = dictionary1.Keys.Count;

            dictionary1.Remove("aaa");
            dictionary1.Remove("Proxy-Connection");
            dictionary1.Remove("Proxy.Connection");
            dictionary1.Remove(key);

            dictionary1.Clear();

            dictionary1["asd"] = 3;
            object val = dictionary1["asd"];

            dictionary1.Add("hello", "bye");

            dictionary1.ContainsKey("asd");

            foreach (KeyValuePair<string, object> pair in dictionary1)
            {
                string myKey = pair.Key;
                object myValue = pair.Value;
            }

            ICollection<string> keys = dictionary1.Keys;
            ICollection<object> values = dictionary1.Values;
        }

        public void TestIDictionary_T(int arg) {
            IDictionary<string, object> dictionary1 = new Dictionary<string, object>();
            string key = "blah";
            int c = dictionary1.Keys.Count;

            dictionary1.Remove("aaa");
            dictionary1.Remove("Proxy-Connection");
            dictionary1.Remove("Proxy.Connection");
            dictionary1.Remove(key);

            dictionary1.Clear();

            dictionary1["asd"] = 3;
            object val = dictionary1["asd"];

            dictionary1.Add("hello", "bye");

            dictionary1.ContainsKey("asd");

            foreach (KeyValuePair<string, object> pair in dictionary1)
            {
                string myKey = pair.Key;
                object myValue = pair.Value;
            }

            ICollection<string> keys = dictionary1.Keys;
            ICollection<object> values = dictionary1.Values;
        }

        public void TestIDictionary(int arg) {
            IDictionary dictionary1 = new Dictionary<string, object>();
            string key = "blah";
            int c = dictionary1.Keys.Count;

            dictionary1.Remove("aaa");
            dictionary1.Remove("Proxy.Connection");
            dictionary1.Remove("Proxy-Connection");
            dictionary1.Remove(key);

            dictionary1.Clear();

            dictionary1["asd"] = 3;
            object val = dictionary1["asd"];

            dictionary1.Add("hello", "bye");

            ICollection keys = dictionary1.Keys;
            ICollection values = dictionary1.Values;
        }
    }
}
