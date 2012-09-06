using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]
[assembly: ScriptNamespace("test")]

namespace ValidationTests {

    public class Test {

        public enum Foo {
            A = 0, B = 1
        }

        public class TestEx {
        }
    }
}
