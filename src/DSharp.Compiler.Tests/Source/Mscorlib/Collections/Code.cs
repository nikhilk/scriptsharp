using System;
using System.Collections;
using System.Collections.Generic;

[assembly: ScriptAssembly("test")]

namespace MscorlibTests
{
    public class MyChildrenCollection : MyCollection { }

    public class MyCollection : IList<int>
    {
        public int Count { get { return 2; } }

        public void Add(int item)
        {
        }

        public void Clear()
        {
        }

        public bool Contains(int item)
        {
            return false;
        }

        public void CopyTo(int[] array, int arrayIndex)
        {
        }

        public IEnumerator<int> GetEnumerator()
        {
            return null;
        }

        public bool Remove(int item)
        {
            return false;
        }

        public int this[int index] { get { return 1; } set { } }

        public int IndexOf(int item) { return 1; }

        public void Insert(int index, int item) { }

        public void RemoveAt(int index) { }

        [ScriptIgnore]
        IEnumerator IEnumerable.GetEnumerator()
        {
            return null;
        }
    }

    public static class X
    {
        public static void TestList()
        {
            List<int> c = new List<int>();
            c.Add(12);
            c.AddRange(c);
            c.AddRangeParams(1, 2, 3); // obsolete, but supported on web
            c.Clear();
            c.Contains(12);
            c.Remove(12);
            c.RemoveAt(1);
            c.Insert(0, 11);
            IEnumerator<int> e = c.GetEnumerator();
            int i = c.IndexOf(12);
            c.ForEach(delegate (int n) { ++n; });
            int cc = c.Count;
            c.Insert(1, 22);
            int[] ca = c.ToArray();
        }

        public static void TestIList_T()
        {
            IList<int> c = new List<int>();
            int n = c[0];
            c[0] = c[1];
            c.Add(12);
            c.Clear();
            c.Contains(12);
            c.Remove(12);
            c.RemoveAt(1);
            IEnumerator<int> e = c.GetEnumerator();
            int i = c.IndexOf(12);
            int cc = c.Count;
            c.Insert(1, 22);
        }

        public static void TestIList()
        {
            IList c = new List<int>();
            object n = c[0];
            c[0] = c[1];
            c.Add(12);
            c.Clear();
            c.Contains(12);
            c.Remove(12);
            c.RemoveAt(1);
            IEnumerator e = c.GetEnumerator();
            int i = c.IndexOf(12);
            int cc = c.Count;
            c.Insert(1, 22);
        }

        public static void TestICollection_T()
        {
            ICollection<int> c = new List<int>();
            c.Add(12);
            c.Clear();
            c.Contains(12);
            c.Remove(12);
            IEnumerator<int> e = c.GetEnumerator();
            int cc = c.Count;
        }

        public static void TestICollection()
        {
            ICollection c = new List<int>();
            IEnumerator e = c.GetEnumerator();
            int cc = c.Count;
        }

        public static void TestIReadOnlyList()
        {
            IReadOnlyList<int> c = new List<int>().AsReadOnly();
            object n = c[0];
            IEnumerator e = c.GetEnumerator();
            int cc = c.Count;
        }

        public static void TestArray()
        {
            Array c = new int[4];
            int cl = c.Length;
            IEnumerator e = c.GetEnumerator();
        }

        public static void TestIReadOnlyCollection()
        {
            IReadOnlyCollection<int> c = new List<int>().AsReadOnly();
            IEnumerator e = c.GetEnumerator();
            int cc = c.Count;
        }

        public static void TestIEnumerable_T()
        {
            IEnumerable<int> c = new List<int>();
            IEnumerator<int> e = c.GetEnumerator();
        }

        public static void TestIEnumerable()
        {
            IEnumerable c = new List<int>();
            IEnumerator e = c.GetEnumerator();
        }

        public static void TestCustomList()
        {
            MyCollection c = new MyCollection();
            int n = c[0];
            c[0] = c[1];
            c.Add(12);
            c.Clear();
            c.Contains(12);
            c.Remove(12);
            c.RemoveAt(1);
            c.Insert(0, 11);
            IEnumerator<int> e = c.GetEnumerator();
            int i = c.IndexOf(12);
            int cc = c.Count;
            c.Insert(1, 22);
        }

        public static void TestCustomInheritedList()
        {
            MyChildrenCollection c = new MyChildrenCollection();
            int n = c[0];
            c[0] = c[1];
            c.Add(12);
            c.Clear();
            c.Contains(12);
            c.Remove(12);
            c.RemoveAt(1);
            c.Insert(0, 11);
            IEnumerator<int> e = c.GetEnumerator();
            int i = c.IndexOf(12);
            int cc = c.Count;
            c.Insert(1, 22);
        }
    }
}
