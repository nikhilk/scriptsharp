using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Testing;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace EquatableTest
{
    public class TestClass
    {
        public TestClass()
        {
            TestObject obj = new TestObject
            {
                Text = "Hello",
            };

            bool x = obj.Equals(obj);

            if (obj is IEquatable<TestObject>)
            {
                obj.Text = "wow";
            }
        }
    }

    public class TestObject : IEquatable<TestObject>
    {
        public string Text { get; set; }

        public bool Equals(TestObject other)
        {
            return Text == other.Text;
        }
    }
}
