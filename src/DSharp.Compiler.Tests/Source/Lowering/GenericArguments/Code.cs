using System;
using System.Collections.Generic;

[assembly: ScriptAssembly("test")]

namespace LoweringTests
{
    public class GenericClass<T1>
    {
        public T1 GenericMethod1<T2>(T2 arg)
        {
            throw new NotImplementedException();
        }

        public T2 GenericMethod2<T2>(T2 arg)
        {
            throw new NotImplementedException();
        }

        public T1 GenericMethod3(T1 arg)
        {
            throw new NotImplementedException();
        }
    }

    public class App
    {
        private void Foo()
        {
            GenericClass<int> subject = new GenericClass<int>();
            int x = subject.GenericMethod1("test");
            string y = subject.GenericMethod2("test");

#if TEST
            int a = subject.GenericMethod3(123);
#else
            int z = subject.GenericMethod3(123);
#endif
        }
    }
}
