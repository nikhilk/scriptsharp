using System.Collections.Generic;

[assembly: ScriptAssembly("test")]

namespace DSharp.Compiler.Tests.Source.Expression.GenericsReturnTypeDeduction
{
    class X<T> { }

    public class Program
    {
        public static void Main(string[] args)
        {
            int length = Cast<string>((object)"TEST_STRING").Length;
            int length2 = ToList(new[] { "asd" })[0].Length;

            var x = new X<int>();
            bool isX = x is X<string>;
            bool isXofX = x is X<X<string>>;

            var xAsX = x as X<int>;
            var xAsXofX = x as X<X<string>>;

            var result = ToList(new[] { "asd" }).GenericExtensionMethod().Length;
        }

        private static T Cast<T>(object x)
        {
            return (T)x;
        }

        private static System.Collections.Generic.IList<T> ToList<T>(IEnumerable<T> source)
        {
            return null;
        }
    }

    public static class ExtensionMethods
    {
        public static T GenericExtensionMethod<T>(this IEnumerable<T> source)
            where T : class
        {
            return null;
        }
    }
}
