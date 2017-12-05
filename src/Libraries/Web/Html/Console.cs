// ClientRect.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Html {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("console")]
    public static class Console
    {
        
        public static extern void Log(object message);
        public static extern void Log(string message, params object[] args);

        public static extern void Warn(object message);
        public static extern void Warn(string message, params object[] args);

        public static extern void Error(object message);
        public static extern void Error(string message, params object[] args);

        public static extern void Clear();
    }
}
