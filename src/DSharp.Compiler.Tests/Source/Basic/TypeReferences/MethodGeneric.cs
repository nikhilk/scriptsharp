using System;
using Library;

[assembly: ScriptAssembly("test")]

namespace BasicTests
{
    public class App
    {
        private int FooGeneric<T>()
        {
            return 42;
        }

        private int Foo()
        {
            return FooGeneric<StructInLib>();
        }
    }
}
