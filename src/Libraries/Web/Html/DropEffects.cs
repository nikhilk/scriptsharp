// DropEffects.cs
// Script#/Libraries/Web
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [IgnoreNamespace]
    [Imported]
    [NamedValues]
    public enum DropEffects {

        Copy = 0,

        Link = 1,

        Move = 2,

        CopyLink = 3,

        CopyMove = 4,

        LinkMove = 5,

        All = 6,

        None = 7
    }
}
