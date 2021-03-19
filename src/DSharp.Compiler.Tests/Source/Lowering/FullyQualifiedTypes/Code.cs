using System;
#if X
using OtherNamespace;
#endif

[assembly: ScriptAssembly("test")]

namespace Some.Namespace
{
    public class Bar
    {
        extern public Bar();

        public Bar(Bar bar)
        {

        }

        public class NestedClass
        {
            extern public NestedClass();

            public NestedClass(Bar bar)
            {

            }
        }
    }

    public class Bar<T>
    {
        public Bar(T t)
        {

        }
    }
}

namespace FullyQualifiedTypesTests
{
    public class Foo
    {
        public void Main()
        {
            Some.Namespace.Bar bar = new Some.Namespace.Bar(new Some.Namespace.Bar());
            Some.Namespace.Bar<Some.Namespace.Bar> bart = new Some.Namespace.Bar<Some.Namespace.Bar>(new Some.Namespace.Bar());
            Some.Namespace.Bar.NestedClass bar2 = new Some.Namespace.Bar.NestedClass(new Some.Namespace.Bar());
            Some.Namespace.Bar<Some.Namespace.Bar.NestedClass> bart2 = new Some.Namespace.Bar<Some.Namespace.Bar.NestedClass>(new Some.Namespace.Bar.NestedClass());
            new Foo.NestedFoo();
        }

        public class NestedFoo
        {
            //public System.Threading.Tasks.Task TaskAsync()
            //{

            //}
        }
    }
}
