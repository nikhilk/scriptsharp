using System;

namespace LoweringTests
{
    using MissingUsing;

    public class X
    {
        public static void Y(Func<Z, bool> z) { }
    }
}

namespace MissingUsing
{
    public class Z { }
}
