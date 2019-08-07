using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]


namespace ValidationTests {

    [ScriptModule]
    public static class A {
    }

    [ScriptModule]
    internal static class B {

        static B() {
        }

        public static void Foo() {
        }
    }
}
