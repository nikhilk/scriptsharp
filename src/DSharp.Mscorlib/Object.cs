using System.Runtime.CompilerServices;

namespace System
{
    /// <summary>
    /// Equivalent to the Object type in Javascript.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    public partial class Object
    {
        //TODO: Look at removing
        [ScriptName("name")]
        public const string NAME_DEFINITION = "Object";

        /// <summary>
        /// Retrieves the type associated with an object instance.
        /// </summary>
        /// <returns>The type of the object.</returns>
        [DSharpScriptMemberName("typeOf")]
        public extern Type GetType();

        /// <summary>
        /// Converts an object to its string representation.
        /// </summary>
        /// <returns>The string representation of the object.</returns>
        public extern virtual string ToString();

        // In CLR object has 
        // bool Equals(object o), 
        // static bool Equals(object a, object b) and 
        // static bool ReferenceEquals(object a, object b)
    }
}
