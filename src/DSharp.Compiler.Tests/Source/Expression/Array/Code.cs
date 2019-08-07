using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace ExpressionTests {
    public class App {
        public void Test(int arg) {
            List<int> numbers = new List<int>();
            numbers.Add(1);
            numbers[1] = numbers[0];
            numbers.AddRange(numbers);
            numbers.Clear();
            bool b2 = numbers.Contains(4);
            numbers.Insert(1, 10);
            numbers.RemoveAt(4);

            string[] words = new string[5];
            words[0] = "hello";
            words[1] = "world";
            bool b3 = words.Contains("hi");

            IEnumerator<int> enumerator;
            int count;

            IList<int> x = new List<int>();
            x.Add(2);
            x[1] = x[0];
            enumerator = x.GetEnumerator();
            count = x.Count;

            IList a = new List<int>();
            a.Add(2);
            a[1] = a[0];
            enumerator = a.GetEnumerator();
            count = a.Count;

            ICollection<int> c = new List<int>();
            c.Add(2);
            enumerator = c.GetEnumerator();
            count = c.Count;
        }
    }
}
