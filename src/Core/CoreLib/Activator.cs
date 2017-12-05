// Activator.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections;
using System.Runtime.CompilerServices;

namespace System {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("ss")]
    public static class Activator
    {
        public static extern object CreateInstance(Type type);
        public static extern T CreateInstance<T>();

        public static object CreateInstance(Type type, params object[] args)
        {
            return null;
        }
    }
}
