// Single.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace System {

    /// <summary>
    /// The float data type which is mapped to the Number type in Javascript.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("Number")]
    public struct Single {

        [ScriptAlias("parseFloat")]
        public static float Parse(string s) {
            return 0;
        }

        /// <summary>
        /// Returns a string containing the value represented in exponential notation.
        /// </summary>
        /// <returns>The exponential representation</returns>
        public string ToExponential() {
            return null;
        }

        /// <summary>
        /// Returns a string containing the value represented in exponential notation.
        /// </summary>
        /// <param name="fractionDigits">The number of digits after the decimal point (0 - 20)</param>
        /// <returns>The exponential representation</returns>
        public string ToExponential(int fractionDigits) {
            return null;
        }

        /// <summary>
        /// Returns a string representing the value in fixed-point notation.
        /// </summary>
        /// <returns>The fixed-point notation</returns>
        public string ToFixed() {
            return null;
        }

        /// <summary>
        /// Returns a string representing the value in fixed-point notation.
        /// </summary>
        /// <param name="fractionDigits">The number of digits after the decimal point from 0 - 20</param>
        /// <returns>The fixed-point notation</returns>
        public string ToFixed(int fractionDigits) {
            return null;
        }

        /// <summary>
        /// Returns a string containing the value represented either in exponential or
        /// fixed-point notation with a specified number of digits.
        /// </summary>
        /// <returns>The string representation of the value.</returns>
        public string ToPrecision() {
            return null;
        }

        /// <summary>
        /// Returns a string containing the value represented either in exponential or
        /// fixed-point notation with a specified number of digits.
        /// </summary>
        /// <param name="precision">The number of significant digits (in the range 1 to 21)</param>
        /// <returns>The string representation of the value.</returns>
        public string ToPrecision(int precision) {
            return null;
        }

        /// <internalonly />
        public static implicit operator Number(float i) {
            return null;
        }
    }
}
