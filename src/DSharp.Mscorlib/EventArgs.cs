using System.Runtime.CompilerServices;

namespace System
{
    /// <summary>
    /// Used by event sources to pass event argument information.
    /// </summary>
    [ScriptImport]
    public class EventArgs
    {
        /// <summary>
        /// A static object of type <see cref="EventArgs"/> that is used as a convenient way to
        /// specify an empty EventArgs instance.
        /// </summary>
        [ScriptName(PreserveCase = true)]
        public static readonly EventArgs Empty = null;
    }
}
