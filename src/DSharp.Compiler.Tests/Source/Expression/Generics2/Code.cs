using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Serialization;

[assembly: ScriptAssembly("test")]

namespace ExpressionTests
{
    public class TestBase
    {
        public void PerformAction() { }
    }

    public class TestDisposableBase : TestBase, IDisposable
    {
        public void Dispose() { }
    }

    public class Program
    {
        public void Main()
        {
            NoParameters<int>();
            NoParameters<TestBase>();

            NoParametersConstrained<TestDisposableBase>();
            NoParametersConstrained<IDisposable>();

            InParameter(1234);
            InParameter(1234f);
            InParameter<double>(1234);

            InParameterConstrained<TestDisposableBase>(new TestDisposableBase());
            InParameterConstrained<IDisposable>(new TestDisposableBase());

            ComplexInGenerics(new TestDisposableBase(), new TestDisposableBase());
        }

        public void NoParameters<T>()
        {
        }

        public void NoParametersConstrained<T>()
            where T : IDisposable
        {
        }

        public object InParameter<T>(T inGenericParameter)
        {
            return inGenericParameter;
        }

        public void InParameterConstrained<T>(T x)
            where T : IDisposable
        {
            Type xType = x.GetType();

            x.Dispose();
        }

        public void ComplexInGenerics<T, Y>(T a1, Y a2)
            where T : IDisposable
            where Y : TestBase, IDisposable
        {
            a1.Dispose();

            a2.PerformAction();
            a2.Dispose();
        }
    }
}
