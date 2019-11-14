using System;
using Library;

[assembly: ScriptAssembly("test")]

namespace BasicTests
{
    public static class App
    {
        public static void Foo(this InterfaceInLib extendedType) { }
    }
}
