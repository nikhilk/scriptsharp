// Action.cs
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
    public delegate void Action();

    [IgnoreNamespace]
    [Imported]
    public delegate void Action<T>(T arg);

    [IgnoreNamespace]
    [Imported]
    public delegate void Action<T1, T2>(T1 arg1, T2 arg2);
}
