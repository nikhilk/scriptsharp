using System.Runtime.CompilerServices;

namespace System.Reflection
{
    [ScriptImport]
    [ScriptIgnoreNamespace]
    public abstract class FieldInfo : MemberInfo
    {
        [ScriptName("Type")]
        public virtual Type FieldType { get; }
    }
}
