using System.Runtime.CompilerServices;

namespace System
{
    //TODO: Move this type to the javascript library
    /// <summary>
    /// Equivalent to the Number type in Javascript.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class Number
    {
        [ScriptName("MAX_VALUE")]
        public const double MaxValue = 0;

        [ScriptName("MIN_VALUE")]
        public const double MinValue = 0;

        [ScriptName(PreserveCase = true)]
        public const double NaN = 0;

        [ScriptName("NEGATIVE_INFINITY")]
        public const double NegativeInfinity = 0;

        [ScriptName("POSITIVE_INFINITY")]
        public const double PositiveInfinity = 0;

        [ScriptAlias("isFinite")]
        public extern static bool IsFinite(Number n);

        [ScriptAlias("isNaN")]
        public extern static bool IsNaN(Number n);

        [DSharpScriptMemberName("number")] //TODO: Should be parseNumber
        public extern static Number Parse(string s);

        [ScriptAlias("parseFloat")]
        public extern static double ParseDouble(string s);

        [ScriptAlias("parseFloat")]
        public extern static float ParseFloat(string s);

        [ScriptAlias("parseInt")]
        public extern static int ParseInt(float f);

        [ScriptAlias("parseInt")]
        public extern static int ParseInt(double d);

        [ScriptAlias("parseInt")]
        public extern static int ParseInt(string s);

        [ScriptAlias("parseInt")]
        public extern static int ParseInt(string s, int radix);

        /// <summary>
        /// Returns a string containing the number represented in exponential notation.
        /// </summary>
        /// <returns>The exponential representation</returns>
        public extern string ToExponential();

        /// <summary>
        /// Returns a string containing the number represented in exponential notation.
        /// </summary>
        /// <param name="fractionDigits">The number of digits after the decimal point (0 - 20)</param>
        /// <returns>The exponential representation</returns>
        public extern string ToExponential(int fractionDigits);

        /// <summary>
        /// Returns a string representing the number in fixed-point notation.
        /// </summary>
        /// <returns>The fixed-point notation</returns>
        public extern string ToFixed();

        /// <summary>
        /// Returns a string representing the number in fixed-point notation.
        /// </summary>
        /// <param name="fractionDigits">The number of digits after the decimal point from 0 - 20</param>
        /// <returns>The fixed-point notation</returns>
        public extern string ToFixed(int fractionDigits);

        /// <summary>
        /// Returns a string containing the number represented either in exponential or
        /// fixed-point notation with a specified number of digits.
        /// </summary>
        /// <returns>The string representation of the value.</returns>
        public extern string ToPrecision();

        /// <summary>
        /// Returns a string containing the number represented either in exponential or
        /// fixed-point notation with a specified number of digits.
        /// </summary>
        /// <param name="precision">The number of significant digits (in the range 1 to 21)</param>
        /// <returns>The string representation of the value.</returns>
        public extern string ToPrecision(int precision);

        /// <summary>
        /// Converts the value to its string representation.
        /// </summary>
        /// <param name="radix">The radix used in the conversion (eg. 10 for decimal, 16 for hexadecimal)</param>
        /// <returns>The string representation of the value.</returns>
        public extern string ToString(int radix);

        public extern static implicit operator int(Number n);
    }
}
