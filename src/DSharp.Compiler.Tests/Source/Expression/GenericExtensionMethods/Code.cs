using System;
using System.Collections.Generic;

[assembly: ScriptAssembly("ExpressionTests.GenericExtensionMethods")]

namespace TypeTests
{
    public class ITestData
    {

    }

    public class ITestData2
    {

    }

    public static class NoneGenericExtensions
    {
        public static ITestData NoneGenericExtension(this ITestData value, string a)
        {
            return value;
        }
    }

    public static class GenericExtensions
    {
        public static TValue GenericExtension<TValue>(this TValue value, string a)
        {
            return value;
        }
    }

    public class Test
    {
        public ITestData Data { get; private set; }

        public void Func()
        {
            Data
                .NoneGenericExtension("A")
                .NoneGenericExtension("B");

            Data
                .GenericExtension("A")
                .GenericExtension("B");

            Data
                .NoneGenericExtension("A")
                .GenericExtension("B");

            Data
                .GenericExtension("A")
                .NoneGenericExtension("B");
        }
    }
}
