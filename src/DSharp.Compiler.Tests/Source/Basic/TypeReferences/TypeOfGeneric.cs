using System;
using Library;

[assembly: ScriptAssembly("test")]

namespace BasicTests
{
    public class App
    {
        public App()
        {
            Type type = typeof(GenericType<InterfaceInLib>);
        }
    }

    public class GenericType<TArg> { }
}
