using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Testing;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace ComparableTest
{
    public class TestClass
    {
        public TestClass()
        {
            TestObject obj = new TestObject
            {
                Text = "Hello",
            };

            int x = obj.Compare(obj);

            if (obj is IComparable<TestObject>)
            {
                obj.Text = "wow";
            }
        }
    }

    public class TestObject : IComparable<TestObject>
    {
        public string Text { get; set; }

        public int Compare(TestObject other)
        {
            return Text == other.Text ? 0 : -1;
        }
    }
}
