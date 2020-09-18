using System;
using static System.Console;

[assembly: ScriptAssembly("test")]

namespace LoweringTests
{
    public class App
    {
        private void Foo()
        {
            WriteLine("hello");
        }
    }
}
