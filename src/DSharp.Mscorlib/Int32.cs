using System.Runtime.CompilerServices;

namespace System
{
    /// <summary>
    /// The int data type which is mapped to the Number type in Javascript.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("Number")]
    public struct Int32
    {
        [ScriptName("MAX_VALUE")]
        public const int MaxValue = 0;

        [ScriptName("MIN_VALUE")]
        public const int MinValue = 0;

        [ScriptAlias("parseInt")]
        public extern static int Parse(string s);

        [ScriptAlias("parseInt")]
        public extern static int Parse(string s, int radix);

        /// <summary>
        /// Converts the value to its string representation.
        /// </summary>
        /// <param name="radix">The radix used in the conversion (eg. 10 for decimal, 16 for hexadecimal)</param>
        /// <returns>The string representation of the value.</returns>
        public extern string ToString(int radix);

        //TODO: Move to Number type
        public extern static implicit operator Number(int i);
    }
}
