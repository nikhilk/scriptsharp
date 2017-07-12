// Guid.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System {

    [ScriptImport]
    [ScriptName("Guid")]
    public struct Guid {

        [ScriptName(PreserveCase=true)]
        public static Guid NewGuid()
        {
            return new Guid();
        }

        [ScriptSkip]
        public override string ToString()
        {
            return null;
        }
    }
}
