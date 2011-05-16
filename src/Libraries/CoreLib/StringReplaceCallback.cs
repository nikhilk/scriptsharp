// StringReplaceCallback.cs
// Script#/Libraries/CoreLib
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System.Runtime.CompilerServices;

namespace System {

    // TODO: The actual signature needs to be
    //       string callback(match, m1, m2... mN, offset, fullString)
    //       but there isn't a way to express the varying number of parameters in the
    //       middle of the signature!

    [IgnoreNamespace]
    [Imported]
    public delegate string StringReplaceCallback(string matchedValue);
}
