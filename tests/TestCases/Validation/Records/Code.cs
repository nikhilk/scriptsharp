using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]


namespace ValidationTests {

    [ScriptObject]
    public class A {
    }

    [ScriptObject]
    internal sealed class B : Object {
    }

    [ScriptObject]
    internal sealed class C {

        static C() {
        }
    }

    [ScriptObject]
    internal sealed class D {

        public D() {
        }

        public int Value {
            get {
                return 0;
            }
        }
    }
}
