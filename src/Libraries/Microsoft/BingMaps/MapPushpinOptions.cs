// MapPushpinOptions.cs
// Script#/Libraries/Microsoft/BingMaps
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps {

    // TODO: Make properties

    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class MapPushpinOptions {

        public string Icon;
        public string Text;
        public int TextOffset;
        public string TypeName;
        public bool Visible;
        public int ZIndex;
        public int Width;
        public int Height;
        public MapPoint Anchor;
        public bool Draggable;
    }
}
