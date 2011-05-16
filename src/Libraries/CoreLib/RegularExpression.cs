// RegularExpression.cs
// Script#/Libraries/CoreLib
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System.Runtime.CompilerServices;

namespace System {

    /// <summary>
    /// Equivalent to the RegExp type in Javascript.
    /// </summary>
    [IgnoreNamespace]
    [Imported]
    [ScriptName("RegExp")]
    public sealed class RegularExpression {

        public RegularExpression(string pattern) {
        }

        public RegularExpression(string pattern, string flags) {
        }

        [IntrinsicProperty]
        public int LastIndex {
            get {
                return 0;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public bool Global {
            get {
                return false;
            }
        }

        [IntrinsicProperty]
        public bool IgnoreCase {
            get {
                return false;
            }
        }

        [IntrinsicProperty]
        public bool Multiline {
            get {
                return false;
            }
        }

        [IntrinsicProperty]
        public string Pattern {
            get {
                return null;
            }
        }

        public string[] Exec(string s) {
            return null;
        }

        public static RegularExpression Parse(string s) {
            return null;
        }

        public bool Test(string s) {
            return false;
        }
    }
}
