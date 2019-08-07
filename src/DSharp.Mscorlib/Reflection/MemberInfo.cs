using System.Runtime.CompilerServices;

namespace System.Reflection
{
    [ScriptImport]
    [ScriptIgnoreNamespace]
    public abstract class MemberInfo
    {
        public virtual string Name { get; }
    }
}
