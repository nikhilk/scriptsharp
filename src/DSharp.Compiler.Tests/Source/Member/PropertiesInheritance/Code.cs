using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace MemberTests
{
    public abstract class AbstractBase
    {
        private bool somethingBase;

        public void UseSomething() { somethingBase = true; }
    }

    public class MyClass : AbstractBase
    {
        private int wow;

        public void UseWow() { ++wow; }
    }

    public class GenericBase<T>
    {
        private bool somethingBase;

        public void UseSomething() { somethingBase = true; }
    }

    public class MyGenericClass : GenericBase<bool>
    {
        private int wow;

        public void UseWow() { ++wow; }
    }
}
