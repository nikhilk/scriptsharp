// TimeService.cs
// Script#/Libraries/Windows
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
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

        public static DateTime GetLocalTime(SidebarTimeZone timeZone) {
            return default(DateTime);
        }
    }
}
