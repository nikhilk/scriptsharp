using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace ExpressionTests
{
    class Program
    {
        public static void Main(string[] args)
        {
            string str = null;

            MyTestClass mtc = new MyTestClass
            {
                Act = delegate (int inInt) { },
                MyProperty = 1,
                Prop2 = str,
                Func = delegate { return 1; },
                InnerClass = GetInstance().InnerClass
            };

            List<int> list = new List<int>()
            {
                1,
                2,
                3,
                4
            };
        }

        public static MyTestClass GetInstance()
        {
            return new MyTestClass
            {
                MyProperty = (1 + 1 + 2) / 2,
                InnerClass = new MyTestClass()
                {
                    Prop2 = "SomeValue"
                }
            };
        }
    }

    public class MyTestClass
    {
        public int MyProperty { get; set; }

        public string Prop2 { get; set; }

        public MyTestClass InnerClass { get; set; }

        public Action<int> Act { get; set; }

        public Func<int> Func { get; set; }
    }
}
