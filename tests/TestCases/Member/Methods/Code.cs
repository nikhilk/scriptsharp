using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]
[assembly: ScriptNamespace("test")]

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

            string s = String.FromCharCode(0);
            s = String.FromCharCode(32, 65, 66);
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

    [GlobalMethods]
    public static class Foo {

        public static void DoStuff() {
        }
    }

    [Mixin("window")]
    public static class Bar {

        public static void M1() {
        }

        public static void M2() {
        }
    }

    [GlobalMethods]
    public static class FooBar {
    
        static FooBar() {
            Script.Alert("Startup code in FooBar");
        }

        public static void DoStuff2() {
        }
    }

    [GlobalMethods]
    public static class FooBar2 {
    
        static FooBar2() {
            int timeStamp = (new Date()).GetMilliseconds();
            Script.Alert("Startup code in FooBar: " + timeStamp);
        }
    }

    public class X {

        public void Update(int i) { }
    }

    [Mixin("$.fn")]
    public static class Plugin {

        public static X Extend(X x, int i) {
            x.Update(i);
            return x;
        }
    }
}
