using System;
using Library;

[assembly: ScriptAssembly("test")]

namespace BasicTests
{
    public class App
    {
        private void Foo()
        {
            object[] items;
            foreach (ClassInLib item in items) { }
        }
    }
}
