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
        [IntrinsicProperty]
        [ScriptName("current")]
        public static CultureInfo CurrentCulture {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("dtf")]
        public DateFormatInfo DateFormat {
            get {
                return null;
            }
        }

        [PreserveCase]
        [IntrinsicProperty]
        [ScriptName("neutral")]
        public static CultureInfo InvariantCulture {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public string Name {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("nf")]
        public NumberFormatInfo NumberFormat {
            get {
                return null;
            }
        }
    }
}
