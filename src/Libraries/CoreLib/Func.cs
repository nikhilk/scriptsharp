// Func.cs
// Script#/Libraries/CoreLib
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System.Runtime.CompilerServices;

namespace System {

    [IgnoreNamespace]
    [Imported]
    public delegate TResult Func<TResult>();

    [IgnoreNamespace]
    [Imported]
    public delegate TResult Func<T, TResult>(T arg);

    [IgnoreNamespace]
    [Imported]
    public delegate TResult Func<T1, T2, TResult>(T1 arg1, T2 arg2);

    [IgnoreNamespace]
    [Imported]
    public delegate TResult Func<T1, T2, T3, TResult>(T1 arg1, T2 arg2, T3 arg3);

    [IgnoreNamespace]
    [Imported]
    public delegate TResult Func<T1, T2, T3, T4, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4);

    [IgnoreNamespace]
    [Imported]
    public delegate TResult Func<T1, T2, T3, T4, T5, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);

    [IgnoreNamespace]
    [Imported]
    public delegate TResult Func<T1, T2, T3, T4, T5, T6, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6);

    [IgnoreNamespace]
    [Imported]
    public delegate TResult Func<T1, T2, T3, T4, T5, T6, T7, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7);

    [IgnoreNamespace]
    [Imported]
    public delegate TResult Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8);
}
