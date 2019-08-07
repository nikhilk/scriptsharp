using System.Runtime.CompilerServices;

namespace System
{
    [AttributeUsage(AttributeTargets.Enum, Inherited = false, AllowMultiple = false)]
    [ScriptIgnore]
    public sealed class FlagsAttribute : Attribute
    {
    }
}
