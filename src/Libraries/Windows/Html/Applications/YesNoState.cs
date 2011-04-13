// YesNoState.cs
// Script#/Libraries/Windows
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.Applications {

    [IgnoreNamespace]
    [NamedValues]
    [Imported]
    public enum YesNoState {

        [ScriptName("yes")]
        Yes = 0,

        [ScriptName("no")]
        No = 1
    }
}
