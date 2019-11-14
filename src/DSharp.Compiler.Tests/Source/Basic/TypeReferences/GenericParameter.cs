using System;
using Library;

[assembly: ScriptAssembly("test")]

namespace BasicTests
{
    public class App
    {
        public App()
        {
            GenericClass<InterfaceInLib> variable;
        }
    }

    public class GenericClass<T> { }
}
