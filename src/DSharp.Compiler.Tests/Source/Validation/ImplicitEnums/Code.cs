using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]


namespace ValidationTests {

    public enum Test : long {

        A = 0,
        B,
        C = 9223372036854775807L
    }
}
