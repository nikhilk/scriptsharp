using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace System.Runtime.InteropServices
{
    [AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [ScriptIgnore]
    public sealed class OutAttribute : Attribute
    {
    }
}
