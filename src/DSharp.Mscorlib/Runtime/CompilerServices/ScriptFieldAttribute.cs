namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// This attribute denotes a C# property that manifests like a field in the generated
    /// JavaScript (i.e. is not accessed via get/set methods). This is really meant only
    /// for use when defining OM corresponding to native objects exposed to script.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    [ScriptIgnore]
    public sealed class ScriptFieldAttribute : Attribute
    {
    }
}
