using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]


namespace ValidationTests {

    public class Test {
        new public enum TestEnum
        {
        }

        new public interface TestInterface
        {
        }

        new public class TestClass
        {
        }
    }
}
