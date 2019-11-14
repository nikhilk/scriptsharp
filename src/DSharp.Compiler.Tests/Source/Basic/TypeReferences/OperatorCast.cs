using System;
using Library;

[assembly: ScriptAssembly("test")]

namespace BasicTests
{
    public class App
    {
        public App()
        {
            object first = new object();
            object second = (ClassInLib)first;
        }
    }
}
