// Action.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate void Action();

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate void Action<T>(T arg);

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate void Action<T1, T2>(T1 arg1, T2 arg2);

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate void Action<T1, T2, T3>(T1 arg1, T2 arg2, T3 arg3);

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate void Action<T1, T2, T3, T4>(T1 arg1, T2 arg2, T3 arg3, T4 arg4);

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate void Action<T1, T2, T3, T4, T5>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate void Action<T1, T2, T3, T4, T5, T6>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6);

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate void Action<T1, T2, T3, T4, T5, T6, T7>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7);

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate void Action<T1, T2, T3, T4, T5, T6, T7, T8>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8);
}
