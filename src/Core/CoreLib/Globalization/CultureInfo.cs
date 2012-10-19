// CultureInfo.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Globalization {

    [ScriptImport]
    [ScriptName("culture")]
    public sealed class CultureInfo {

        private CultureInfo() {
        }

        [ScriptField]
        [ScriptName("current")]
        public static CultureInfo CurrentCulture {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("dtf")]
        public DateFormatInfo DateFormat {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("neutral")]
        public static CultureInfo InvariantCulture {
            get {
                return null;
            }
        }

        [ScriptField]
        public string Name {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("nf")]
        public NumberFormatInfo NumberFormat {
            get {
                return null;
            }
        }
    }
}
