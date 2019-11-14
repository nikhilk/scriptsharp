using System;
using Library;

[assembly: ScriptAssembly("test")]

namespace BasicTests
{
    public class App
    {
        private void Foo()
        {
            int theAnswer = ClassInLib.Foo();
        }
    }
}
