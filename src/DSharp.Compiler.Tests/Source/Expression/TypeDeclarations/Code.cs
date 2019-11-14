using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace Nothing
{
    public interface ITest { }
    public interface ITest<T> { }

    public class X : IEnumerable, IEnumerable<int?>, ITest, ITest<int?>, IEquatable<int?>
    {
        public X(
            IEnumerable enumerable,
            IEnumerable<int?> t_enumerable,
            IDictionary dict,
            IDictionary<int?, int?> t_dict,
            ITest test,
            ITest<int?> t_test,
            IEquatable<int?> t_equatable)
        {
        }

        [ScriptIgnore]
        IEnumerator IEnumerable.GetEnumerator() { return null; }

        public IEnumerator<int?> GetEnumerator() { return null; }

        public bool Equals(int? other) { return true; }
    }

    public class Hello
    {
        public static void Main()
        {
            Console.WriteLine("Hello World!");
        }
    }
}
