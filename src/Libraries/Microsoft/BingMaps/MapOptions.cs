// MapOptions.cs
// Script#/Libraries/Microsoft/BingMaps
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps {

    // TODO: Make properties

    [Imported]
    [ScriptName("Object")]
    [IgnoreNamespace]
    public sealed class MapOptions {

        public MapColor BackgroundColor;
        public bool ShowDashboard;
        public bool ShowBreadcrumb;
        public int Zoom;
        public bool ShowScalebar;
        public bool ShowCopyright;
        public bool ShowMapTypeSelector;
        public int Width;
        public int Height;
        public MapLocation Center;
        public string Credentials;
        public bool EnableClickableLogo;
        public bool EnableSearchLogo;
        public bool ShowNavControl;
        public bool ShowLogo;
        public bool DisableUserInput;
        public bool DisableBirdseye;
        public bool DisableKeyboardInput;
        public bool DisableMouseInput;
        public bool DisablePanning;
        public bool DisableTouchInput;
        public bool DisableZooming;
        public bool FixedMapPosition;
        public bool UseInertia;
        public double InertiaIntensity;
        public int TileBuffer;
        [ScriptName("mapTypeId")]
        public MapType MapType;
    }
}
