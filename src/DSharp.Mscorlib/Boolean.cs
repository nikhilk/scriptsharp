using System.Runtime.CompilerServices;

namespace System
{
    /// <summary>
    /// Equivalent to the Boolean type in Javascript.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    public struct Boolean
    {
        /// <summary>
        /// Enables you to parse a string representation of a boolean value.
        /// </summary>
        /// <param name="s">The string to be parsed.</param>
        /// <returns>The resulting boolean value.</returns>
        [DSharpScriptMemberName("boolean")] //TODO: Should be parseBoolean
        public extern static bool Parse(string s);
    }
}
