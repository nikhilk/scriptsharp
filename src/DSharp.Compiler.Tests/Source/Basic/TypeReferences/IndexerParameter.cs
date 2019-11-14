using System;
using Library;

[assembly: ScriptAssembly("test")]

namespace BasicTests
{
    public class App
    {
        public string this[InterfaceInLib key]
        {
            get { return null; }
        }
    }
}
