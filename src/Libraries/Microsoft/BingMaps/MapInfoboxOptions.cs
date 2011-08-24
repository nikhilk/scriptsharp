// MapInfoboxOptions.cs
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
    public sealed class MapInfoboxOptions {

        public MapInfoBoxAction[] Actions;
        public string Description;
        public int Height;
        public string HtmlContent;
        public string ID;
        public MapLocation Location;
        public MapPoint Offset;
        public bool ShowCloseButton;
        public bool ShowPointer;
        public string Title;
        public string TitleClickHandler;
        public bool Visible;
        public int Width;
        public int ZIndex;
    }
}
