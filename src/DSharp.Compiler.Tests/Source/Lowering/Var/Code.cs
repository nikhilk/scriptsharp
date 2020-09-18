using System;
using System.Collections.Generic;
using Number = System.Double;
[assembly: ScriptAssembly("test")]

namespace LoweringTests
{
    using n1;

    public class App
    {
        private void Foo()
        {
            var str = "string";
            var num = 2;
            var c = new c1().C2;
            var nest = new c1.Nest();
            var n = (Number)num;
            var list = new List<string>();
            var array = new object[] { false, 1, "2" };
            var anon = new { Prop1=false, Prop2=1, Prop3="2" };
        }
    }
}

namespace n1
{
    using n2;

    public class c1
    {
        public c2 C2 { get; set; }

        public class Nest
        {
        }
    }
}

namespace n2
{
    public class c2
    {

    }
}
