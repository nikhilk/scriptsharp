using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Testing;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace CloneableTest
{
    public class TestClass
    {
        public TestClass()
        {
            TestObject obj = new TestObject
            {
                Text = "Hello",
            };

            TestObject clonedObj = obj.Clone();

            if (obj is ICloneable)
            {
                obj.Text = "wow";
            }

            if (clonedObj is ICloneable)
            {
                clonedObj.Text = "wow";
            }
        }
    }

    public class TestObject : ICloneable
    {
        public string Text { get; set; }

        public object Clone()
        {
            return new TestObject
            {
                Text = this.Text
            };
        }
    }
}
