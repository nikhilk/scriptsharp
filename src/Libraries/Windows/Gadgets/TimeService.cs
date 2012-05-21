// TimeService.cs
// Script#/Libraries/Windows
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Gadgets {

    /// <summary>
    /// A service that enables retrieving time and time zone information.
    /// </summary>
    [IgnoreNamespace]
    [Imported]
    public static class TimeService {

        [IntrinsicProperty]
        public static SidebarTimeZone[] TimeZones {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public static SidebarTimeZone CurrentTimeZone {
            get {
                return null;
            }
        }

        public static Date GetLocalTime(SidebarTimeZone timeZone) {
            return null;
        }
    }
}
