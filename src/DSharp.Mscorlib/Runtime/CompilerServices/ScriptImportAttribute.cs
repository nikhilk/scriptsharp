namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// This attribute can be placed on types that should not be emitted into generated
    /// script, as they represent existing script or native types.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Enum | AttributeTargets.Delegate | AttributeTargets.Struct)]
    [ScriptIgnore]
    [ScriptImport]
    public sealed class ScriptImportAttribute : Attribute
    {
    }
}
