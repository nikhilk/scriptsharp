using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Testing;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace GuidTests
{

    public class PublicClass
    {
        public PublicClass()
        {
            String guid = Guid.NewGuid().ToString();
        }
    }
}
