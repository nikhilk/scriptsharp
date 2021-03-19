

using System.Collections;
using System.Collections.Generic;

[assembly: ScriptAssembly("test")]

namespace MemberTests
{
    public interface IGrouping<TKey, TElement> : IEnumerable<TElement>, IEnumerable
    {
        TKey Key { get; }
    }

    public abstract class Grouping<TKey, TElement> : IGrouping<TKey, TElement>
    {
    }

    public static class GenericTestExtensions
    {
        public static void DoExtension<T1, T2, T>(this GenericTest<T1, T2> i, T1 a, T2 b, T c)
        {
            GenericTest<T1, T2>.DoStatic3(a, b, c);
            i.DoInstance(a, b, c);
        }

        public static T FirstOrDefault<T>(this IEnumerable<T> source, T defaultV)
        {
            return defaultV;
        }
    }

    public class GenericTest<T1,T2>
    {
        public static void DoStatic()
        {
        }

        public static void DoStatic2(T1 a, T2 b)
        {
        }

        public static void DoStatic3<T>(T1 a, T2 b, T c)
        {
        }

        public void DoInstance<T>(T1 a, T2 b, T c)
        {

        }
    }

    public abstract class Test
    {
        public void Do1()
        {
            GenericTest<int, string>.DoStatic();
            GenericTest<bool, int>.DoStatic2(false, 42);
            GenericTest<bool, int>.DoStatic3(false, 42, "wow");

            GenericTest<int, string> instance = new GenericTest<int, string>();
            instance.DoExtension(42, "wow", '2');

            Grouping<string, int> x = null;
            x.FirstOrDefault(1234);
        }

        public int Do2()
        {
            return 0;
        }

        public object Do3(int i, int j)
        {
            return i;
        }

        public int Do4(int zero, params object[] stuff)
        {
            return stuff.Length;
        }

        public void Do5(params object[] stuff)
        {
        }

        public void Do6<T>(params T[] someValues)
        {
        }

        public void Do7(int a, int b = 2)
        {

        }

        public void Do8(int a=1, int b = 2, string c = "3", string d = "4")
        {
            Do8(b:1);
            Do8();
            Do8(1);
            Do8(1,2);
            Do8(1,2,"3");
            Do8(1,2, "3","4");
            Do8();
            Do8(a:1);
            Do8(c:"3", d:"2");
            Do8(a:1, d:"3", b:2);
        }

        public void Run()
        {
            Do1();
            int v = Do2();

            string s = String.FromChar('A', 3);
            int i = s.IndexOf('A');
            i = s.IndexOf('A', 1);
            int ln = Do4(0, 1, 2, 3, "a", "b", "c", true, false);
            Do5();
            Do6<int>(1, 2, 3);
            Do6<X.Y<string>>();
            Do3(j: 5, i: 2);
            Do7(1);
            DoSomethingCrazy("lo", b: "co");
        }

        public string DoSomethingCrazy(string a, string b = "co")
        {
            return a + b;
        }

        public abstract object getRunOptions();

        public override string ToString()
        {
            X x = new X();

            return null;
        }
    }

    public class X
    {
        public void Update(int i) { }

        public class Y<T>
        {

        }
    }
}
