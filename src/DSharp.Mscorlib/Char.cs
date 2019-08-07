using System.Runtime.CompilerServices;

namespace System
{

    /// <summary>
    /// The char data type which is mapped to the String type in Javascript.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("String")]
    public struct Char
    {
        /// <internalonly />
        public extern static explicit operator string(char ch);
    }
}
