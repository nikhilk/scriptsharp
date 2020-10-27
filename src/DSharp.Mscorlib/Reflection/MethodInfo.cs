using System.Runtime.CompilerServices;

namespace System.Reflection
{
    [ScriptImport]
    [ScriptIgnoreNamespace]
    public abstract class MethodInfo : MemberInfo
    {
        [ScriptName("Type")]
        public virtual Type ReturnType { get; }

        public virtual bool IsGenericMethod { get; }
    }
}
