using System;
using System.Collections.Generic;

[assembly: ScriptAssembly("test")]

namespace LoweringTests
{
    public class App
    {
        private void Foo()
        {
            object[] array = new object[] { false, 1, "2" };
            List<object> list = new List<object> { false, 1, "2" };

            C1 c = new C1()
            { 
                BoolProp = false, 
                StringProp = null, 
                C1Prop = new C1 { BoolProp = true },
                DictProp = new Dictionary<string, object>() { 
                    { "test", true }, 
                    { "test2", false } 
                }
            };

#if TEST
            C2 c2 = new C2("hello")
            {
                Prop = "world"
            };
#else
            C2 c2 = new C2("hello")
            {
                Prop = "world"
            };
#endif

            TestFunc(new C1()
            {
                BoolProp = false
            });
        }

        private void TestFunc(C1 obj)
        {
            throw new NotImplementedException();
        }
    }

    public class C1
    {
        public bool BoolProp { get; set; }
        public string StringProp { get; set; }
        public C1 C1Prop { get; set; }
        public Dictionary<string, object> DictProp { get; set; }
    }

    public class C2
    {
        public string Prop { get; set; }

        public C2(string arg)
        {

        }
    }
}
