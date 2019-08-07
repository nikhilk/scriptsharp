using System.Runtime.CompilerServices;

namespace System.ComponentModel
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    [ScriptIgnore]
    public enum EditorBrowsableState
    {
        Always = 0,
        Never = 1,
        Advanced = 2
    }
}
