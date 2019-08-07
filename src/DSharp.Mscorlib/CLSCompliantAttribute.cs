using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace System
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    [ScriptIgnore]
    public sealed class CLSCompliantAttribute : Attribute
    {
        public CLSCompliantAttribute(bool isCompliant)
        {
            IsCompliant = isCompliant;
        }

        public bool IsCompliant { get; }
    }
}
