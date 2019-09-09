using System.ComponentModel;

namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// This attribute can be placed on types/methods in system script assemblies that should not be imported/transpiled.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.Delegate | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    [ScriptIgnore]
    [ScriptImport]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class ScriptIgnoreAttribute : Attribute
    {
    }
}
