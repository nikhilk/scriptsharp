using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace TypeTests {

    [ScriptName("FooBaz")]
    public class Foo {
    }

    [ScriptName("BarBaz")]
    public class Bar {
        public Bar(Foo f)
        {

        }
    }

    public class MyClass {
        public MyClass() { Foo f = new Foo(); }
    }

    public class MyClass2 : MyClass {
    }

    public class MyClass3 : IDisposable {
    }

    public class MyClass4 : MyClass, IDisposable {

        public MyClass4(Foo foo, Bar bar, IDisposable disposable)
        {
            Foo f = Activator.CreateInstance<Foo>();
            Bar b = Activator.CreateInstance(typeof(Bar), f);
        }
    }

    public static class StaticClass {
    }
}
