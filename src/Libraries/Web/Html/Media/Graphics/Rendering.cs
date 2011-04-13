// Rendering.cs
// Script#/Libraries/Web
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.Media.Graphics {

    [IgnoreNamespace]
    [Imported]
    [NamedValues]
    public enum Rendering {

        [ScriptName("2d")]
        Render2D,

        [ScriptName("3d")]
        Render3D
    }
}
