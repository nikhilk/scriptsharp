// Void.cs
// Script#/Libraries/CoreLib
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace System {

    // This doesn't map to an actual type, but needs to be present
    // in the set of types, so that the C# void type can be mapped
    [IgnoreNamespace]
    [Imported]
    public struct Void {
    }
}
