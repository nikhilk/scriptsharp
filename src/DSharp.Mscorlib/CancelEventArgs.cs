using System.Runtime.CompilerServices;

namespace System
{
    /// <summary>
    /// The event argument associated with cancelable events.
    /// </summary>
    [ScriptImport]
    public class CancelEventArgs : EventArgs
    {
        /// <summary>
        /// Whether the event has been canceled.
        /// </summary>
        [ScriptField]
        public bool Cancel { get; set; }
    }
}
