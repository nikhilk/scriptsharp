using System;

[assembly: ScriptAssembly("test")]

namespace LoweringTests
{
    public class TestClass
    {
        public void TestMethod()
        {
            var intArray = new[] { 1, 2, 3 };
            
            var stringArray = new [] { 
                "a", 
                "b", 
                "c" 
            };

            var nestedArray = new[] { 
                new[] { true, false },
                new[] { true, false } 
            };
        }
    }
}
