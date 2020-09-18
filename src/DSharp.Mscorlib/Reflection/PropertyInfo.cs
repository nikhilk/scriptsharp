using System.Runtime.CompilerServices;

namespace System.Reflection
{
    [ScriptImport]
    [ScriptIgnoreNamespace]
    public abstract class PropertyInfo : MemberInfo
    {
        [ScriptName("Type")]
        public virtual Type PropertyType { get; }
    }
}
