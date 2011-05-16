// CultureInfo.cs
// Script#/Libraries/CoreLib
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System.Runtime.CompilerServices;

namespace System.Globalization {

    [Imported]
    [ScriptNamespace("ss")]
    public sealed class CultureInfo {

        private CultureInfo() {
        }

        [PreserveCase]
        [IntrinsicProperty]
        public static CultureInfo CurrentCulture {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public DateFormatInfo DateFormat {
            get {
                return null;
            }
        }

        [PreserveCase]
        [IntrinsicProperty]
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
        public NumberFormatInfo NumberFormat {
            get {
                return null;
            }
        }
    }
}
