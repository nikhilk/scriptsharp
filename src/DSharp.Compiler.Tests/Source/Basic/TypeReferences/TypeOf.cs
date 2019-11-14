using System;
using Library;

[assembly: ScriptAssembly("test")]

namespace BasicTests
{
    public class App
    {
        private void Foo()
        {
            if (typeof(ClassInLib) == null)
            {
                return;
            }
        }
    }
}
