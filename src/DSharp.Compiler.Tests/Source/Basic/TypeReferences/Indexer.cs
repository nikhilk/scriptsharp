using System;
using Library;

[assembly: ScriptAssembly("test")]

namespace BasicTests
{
    public class App
    {
        public ClassInLib this[string key]
        {
            get { return null; }
        }
    }
}
