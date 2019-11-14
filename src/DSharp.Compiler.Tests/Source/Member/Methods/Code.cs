using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace MemberTests
{

    public abstract class Test
    {

        public void Do1()
        {
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
    }
}
