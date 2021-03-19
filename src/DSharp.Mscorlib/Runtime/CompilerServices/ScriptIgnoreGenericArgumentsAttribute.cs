namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// Apply to a method to tell the compiler to ignore generic arguments as method parameters
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Struct)]
    [ScriptIgnore]
    public class ScriptIgnoreGenericArgumentsAttribute : Attribute
    {
        public bool UseGenericName { get; set; }
    }
}
