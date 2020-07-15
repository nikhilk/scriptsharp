using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Testing;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace LazyTest
{
    public class TestClass
    {
        public TestClass()
        {
            Lazy<int> myInt = new Lazy<int>(delegate { return 33; });
            bool hasValue = myInt.IsValueCreated;
            int n = myInt.Value;
        }
    }
}
