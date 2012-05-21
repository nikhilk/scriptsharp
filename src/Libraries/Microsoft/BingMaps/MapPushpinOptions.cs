// MapPushpinOptions.cs
// Script#/Libraries/Microsoft/BingMaps
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
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
