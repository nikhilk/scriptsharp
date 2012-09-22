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
            items.Clear();
            bool b1 = items.Contains(2);
            items.Insert(0, 1);
            items.InsertRange(1, 0, 5);
            items.RemoveAt(4);
            items.RemoveRange(4, 3);
            items.Remove(1);
            object[] newItems = items.GetRange(5, 2);
            object[] newItems2 = items.GetRange(5, arg);

            List<int> numbers = new List<int>();
            numbers.Add(1);
            numbers.AddRange(1, 2, 3);
            numbers.Clear();
            bool b2 = numbers.Contains(4);
            numbers.Insert(1, 10);
            numbers.InsertRange(2, 10, 3);
            numbers.RemoveAt(4);
            numbers.RemoveRange(4, 2);
            int[] newNumbers = items.GetRange(5, 2);
            int[] newNumbers2 = items.GetRange(5, arg);

            string[] words = new string[5];
            words[0] = "hello";
            words[1] = "world";
            bool b3 = words.Contains("hi");
            string[] newWords = words.GetRange(5, 2);
            string[] newWords2 = words.GetRange(5, arg);
        }
    }
}
