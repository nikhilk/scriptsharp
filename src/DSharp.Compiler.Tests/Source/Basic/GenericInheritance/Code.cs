using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

[assembly: ScriptAssembly("test")]

namespace BasicTests
{
    public interface IMyThing : IList<int>
    {
    }

    public class Wow : KeyValuePair<int, string>
    {
    }
}
