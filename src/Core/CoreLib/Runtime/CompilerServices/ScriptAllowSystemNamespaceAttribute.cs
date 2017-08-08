namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// This attribute marks the type to be skipped during namespace validation.
    /// Which allows the type to be under the System namespace.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    [ScriptIgnore]
    [ScriptImport]
    public sealed class ScriptAllowSystemNamespaceAttribute : Attribute
    {
    }
}