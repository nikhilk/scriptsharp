using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]


namespace ValidationTests {

    [ScriptExtension("")]
    public static class A {
    }

    [ScriptExtension("$global")]
    public static class B {

        static B() {
        }
    }
}
