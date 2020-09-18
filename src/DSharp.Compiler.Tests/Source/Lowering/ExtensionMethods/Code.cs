using System;
#if X
wooow
#endif

[assembly: ScriptAssembly("test")]

namespace Aadasdasd
{
    public static class AAAA
    {
        public static int What<T>(this object left, T right)
        {
            var x = typeof(T);
            return 6;
        }
    }
}

namespace LoweringTests
{
    using Aadasdasd;

    public static class Extensions
    {
        public static int DoSomething(this int left, int right)
        {
            return left + right;
        }

        public static int DoSomethingElse<T>(this object left, T right)
        {
            var x = typeof(T);
            return 6;
        }
    }

    public static class Main
    {
        public static int WOW = 666;

        public static void Main(this int target)
        {
            int x = 4;
#if !RANDOM_STUFF
            AAAA.What<int>(1, 2);
            AAAA.What<int>(AAAA.What<int>(1, 2), AAAA.What<int>(3, 4));
#else
            x = 3.DoSomething(5); // shouldnt be transformed
#endif
            x = 3.DoSomething(5);
            var a = x.DoSomethingElse(WOW);
#if RANDOM_YEAH
#else
#endif
#if RANDOM_STUFF
            WOW.DoSomethingElse<double>(a).DoSomething(234).What(56); // shouldnt be transformed
#else
            WOW.DoSomethingElse<double>(a).DoSomething(234).What(56);
#endif
            var b = WOW.DoSomethingElse<double>(a).DoSomething(234).What(56);
        }
    }
}
