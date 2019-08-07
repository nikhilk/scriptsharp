using System.Runtime.CompilerServices;

namespace System
{
    /// <summary>
    /// The short data type which is mapped to the Number type in Javascript.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("Number")]
    public struct Int16
    {
        [ScriptName("MAX_VALUE")]
        public const int MaxValue = 0;

        [ScriptName("MIN_VALUE")]
        public const int MinValue = 0;

        /// <summary>
        /// Converts the value to its string representation.
        /// </summary>
        /// <param name="radix">The radix used in the conversion (eg. 10 for decimal, 16 for hexadecimal)</param>
        /// <returns>The string representation of the value.</returns>
        public extern string ToString(int radix);

        //TODO: Move to Number type
        public extern static implicit operator Number(short i);
    }
}
