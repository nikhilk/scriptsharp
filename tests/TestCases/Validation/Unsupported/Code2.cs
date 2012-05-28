using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]
[assembly: ScriptNamespace("test")]

namespace ValidationTests {

    public class Test : IDisposable {

        public Test() {
            System.Diagnostics.Debug.Fail("...");
        }
    }
}
