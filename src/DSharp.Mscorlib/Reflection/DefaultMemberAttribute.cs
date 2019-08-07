using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace System.Reflection
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    [ScriptIgnore]
    public sealed class DefaultMemberAttribute
    {
        public DefaultMemberAttribute(string memberName)
        {
            MemberName = memberName;
        }

        public string MemberName { get; }
    }
}
