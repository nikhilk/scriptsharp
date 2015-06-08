// Decimal.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace System {

    /// <summary>
    /// The decimal data type which is mapped to the Number type in Javascript.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("Number")]
    public struct Decimal {

        public Decimal(double d) {
        }

        public Decimal(int i) {
        }

        public Decimal(float f) {
        }

        public Decimal(long n) {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Decimal(int lo, int mid, int hi, bool isNegative, byte scale) {
        }

        public string Format(string format) {
            return null;
        }

        public string LocaleFormat(string format) {
            return null;
        }

        [ScriptAlias("parseFloat")]
        public static decimal Parse(string s) {
            return 0m;
        }

        /// <summary>
        /// Converts the value to its string representation.
        /// </summary>
        /// <param name="radix">The radix used in the conversion (eg. 10 for decimal, 16 for hexadecimal)</param>
        /// <returns>The string representation of the value.</returns>
        public string ToString(int radix) {
            return null;
        }

        /// <internalonly />
        public static implicit operator Number(decimal i) {
            return null;
        }

        /// <internalonly />
        public static implicit operator decimal(int value) {
            return 0;
        }

        /// <internalonly />
        public static implicit operator decimal(double value) {
            return 0;
        }

        /// <internalonly />
        public static implicit operator decimal(float value) {
            return 0;
        }

        /// <internalonly />
        public static implicit operator decimal(long value) {
            return 0;
        }

        /// <internalonly />
        public static explicit operator int(decimal value) {
            return 0;
        }

        /// <internalonly />
        public static explicit operator double(decimal value) {
            return 0;
        }

        /// <internalonly />
        public static explicit operator float(decimal value) {
            return 0;
        }

        /// <internalonly />
        public static explicit operator long(decimal value) {
            return 0;
        }

        /// <internalonly />
        public static decimal operator +(decimal d) {
            return d;
        }

        /// <internalonly />
        public static decimal operator -(decimal d) {
            return d;
        }

        /// <internalonly />
        public static decimal operator +(decimal d1, decimal d2) {
            return d1;
        }

        /// <internalonly />
        public static decimal operator -(decimal d1, decimal d2) {
            return d1;
        }

        /// <internalonly />
        public static decimal operator ++(decimal d) {
            return d;
        }

        /// <internalonly />
        public static decimal operator --(decimal d) {
            return d;
        }

        /// <internalonly />
        public static decimal operator *(decimal d1, decimal d2) {
            return d1;
        }

        /// <internalonly />
        public static decimal operator /(decimal d1, decimal d2) {
            return d1;
        }

        /// <internalonly />
        public static decimal operator %(decimal d1, decimal d2) {
            return d1;
        }

        /// <internalonly />
        public static bool operator ==(decimal d1, decimal d2) {
            return false;
        }

        /// <internalonly />
        public static bool operator !=(decimal d1, decimal d2) {
            return false;
        }

        /// <internalonly />
        public static bool operator >(decimal d1, decimal d2) {
            return false;
        }

        /// <internalonly />
        public static bool operator >=(decimal d1, decimal d2) {
            return false;
        }

        /// <internalonly />
        public static bool operator <(decimal d1, decimal d2) {
            return false;
        }

        /// <internalonly />
        public static bool operator <=(decimal d1, decimal d2) {
            return false;
        }
    }
}
