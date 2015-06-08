using System;
using System.Html;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace MemberTests {

    public abstract class Test {

        public void Do1() {
        }

        public int Do2() {
            return 0;
        }

        public object Do3(int i, int j) {
            return i;
        }

        public void Run() {
            Do1();
            int v = Do2();

            string s = String.FromChar('A', 3);
            int i = s.IndexOf('A');
            i = s.IndexOf('A', 1);
        }

        public abstract object getRunOptions();

        public override string ToString() {
            Bar.M1();

            X x = new X();
            Plugin.Extend(x, 10);

            return null;
        }
    }

    [ScriptExtension("$global")]
    public static class Foo {

        public static void DoStuff() {
        }
    }

    [ScriptExtension("window")]
    public static class Bar {

        public static void M1() {
        }

        public static void M2() {
        }
    }

    public class X {

        public void Update(int i) { }
    }

    [ScriptExtension("$.fn")]
    public static class Plugin {

        public static X Extend(X x, int i) {
            x.Update(i);
            return x;
        }
    }
}
