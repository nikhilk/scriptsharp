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
}
