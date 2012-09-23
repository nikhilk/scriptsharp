// CultureInfo.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Globalization {

    [Imported]
    [ScriptName("culture")]
    public sealed class CultureInfo {

        private CultureInfo() {
        }

        [PreserveCase]
        [ScriptProperty]
        [ScriptName("current")]
        public static CultureInfo CurrentCulture {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("dtf")]
        public DateFormatInfo DateFormat {
            get {
                return null;
            }
        }

        [PreserveCase]
        [ScriptProperty]
        [ScriptName("neutral")]
        public static CultureInfo InvariantCulture {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public string Name {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("nf")]
        public NumberFormatInfo NumberFormat {
            get {
                return null;
            }
        }
    }
}
