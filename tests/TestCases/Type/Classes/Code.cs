using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace TypeTests {

    [ScriptName("FooBarBaz")]
    public class Foo {
    }

    public class MyClass {
        public MyClass() { Foo = new Foo(); }
    }

    public class MyClass2 : MyClass {
    }

    public class MyClass3 : IDisposable {
    }

    public class MyClass4 : MyClass, IDisposable {
    }
}
