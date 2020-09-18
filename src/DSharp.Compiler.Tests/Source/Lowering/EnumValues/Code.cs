using System;

[assembly: ScriptAssembly("test")]

namespace LoweringTests
{
    public enum IntEnumeration
    {
        Zero,
        One,
        Two
    }

    public enum ShortEnumeration : short
    {
        Zero,
        One,
        Two
    }
}
