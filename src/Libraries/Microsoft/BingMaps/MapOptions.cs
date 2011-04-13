// MapOptions.cs
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
    [ScriptName("Object")]
    [IgnoreNamespace]
    public sealed class MapOptions {

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
        [ScriptName("mapTypeId")]
        public MapType MapType;
    }
}
