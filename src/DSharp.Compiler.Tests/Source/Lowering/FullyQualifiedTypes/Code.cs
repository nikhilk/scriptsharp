using System;
#if X
using OtherNamespace;
#endif

[assembly: ScriptAssembly("test")]

namespace Some.Namespace
{
    public static class Bar
    {
        public Bar(Bar bar)
        {

        }
    }

    public static class Bar<T>
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
        }
    }
}
