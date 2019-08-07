using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace System
{
    /// <summary>
    /// The decimal data type which is mapped to the Number type in Javascript.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("Number")]
    public struct Decimal
    {
        public Decimal(double d) { }

        public Decimal(int i) { }

        public Decimal(float f) { }

        public Decimal(long n) { }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Decimal(int lo, int mid, int hi, bool isNegative, byte scale) { }

        public extern string Format(string format);

        public extern string LocaleFormat(string format);

        [ScriptAlias("parseFloat")]
        public extern static decimal Parse(string s);

        /// <summary>
        /// Converts the value to its string representation.
        /// </summary>
        /// <param name="radix">The radix used in the conversion (eg. 10 for decimal, 16 for hexadecimal)</param>
        /// <returns>The string representation of the value.</returns>
        public extern string ToString(int radix);

        //TODO: Move into Number type
        public extern static implicit operator Number(decimal i);

        /// <internalonly />
        public extern static implicit operator decimal(int value);

        /// <internalonly />
        public extern static implicit operator decimal(double value);

        /// <internalonly />
        public extern static implicit operator decimal(float value);

        /// <internalonly />
        public extern static implicit operator decimal(long value);

        /// <internalonly />
        public extern static explicit operator int(decimal value);

        /// <internalonly />
        public extern static explicit operator double(decimal value);

        /// <internalonly />
        public extern static explicit operator float(decimal value);

        /// <internalonly />
        public extern static explicit operator long(decimal value);

        /// <internalonly />
        public extern static decimal operator +(decimal d);

        /// <internalonly />
        public extern static decimal operator -(decimal d);

        /// <internalonly />
        public extern static decimal operator +(decimal d1, decimal d2);

        /// <internalonly />
        public extern static decimal operator -(decimal d1, decimal d2);

        /// <internalonly />
        public extern static decimal operator ++(decimal d);

        /// <internalonly />
        public extern static decimal operator --(decimal d);

        /// <internalonly />
        public extern static decimal operator *(decimal d1, decimal d2);

        /// <internalonly />
        public extern static decimal operator /(decimal d1, decimal d2);

        /// <internalonly />
        public extern static decimal operator %(decimal d1, decimal d2);

        /// <internalonly />
        public extern static bool operator ==(decimal d1, decimal d2);

        /// <internalonly />
        public extern static bool operator !=(decimal d1, decimal d2);

        /// <internalonly />
        public extern static bool operator >(decimal d1, decimal d2);

        /// <internalonly />
        public extern static bool operator >=(decimal d1, decimal d2);

        /// <internalonly />
        public extern static bool operator <(decimal d1, decimal d2);

        /// <internalonly />
        public extern static bool operator <=(decimal d1, decimal d2);
    }
}
