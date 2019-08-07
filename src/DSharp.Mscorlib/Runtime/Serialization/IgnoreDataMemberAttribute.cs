using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace System.Runtime.Serialization
{
    [AttributeUsageAttribute(AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [ScriptIgnore]
    public sealed class IgnoreDataMemberAttribute : Attribute
    {
    }
}
