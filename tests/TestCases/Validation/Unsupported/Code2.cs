using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]


namespace ValidationTests {

    public class Test : IDisposable {

        public Test() {
            System.Diagnostics.Debug.Fail("...");
        }
    }
}
