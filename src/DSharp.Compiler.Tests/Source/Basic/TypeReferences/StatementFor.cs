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
            int index = 0;
            for (ClassInLib item; index < items.Length; item = items[index]) { }
        }
    }
}
