using System.Runtime.CompilerServices;

namespace System
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    [ScriptIgnore]
    public sealed class ScriptObjectAttribute : Attribute
    {
    }
}
