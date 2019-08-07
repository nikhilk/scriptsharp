namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// Marks a type with a script dependency that is required at runtime.
    /// The specified name is used as the name of the dependency, and the runtime identifier.
    /// </summary>
    [AttributeUsage(AttributeTargets.Type, Inherited = false, AllowMultiple = false)]
    [ScriptIgnore]
    [ScriptImport]
    public sealed class ScriptDependencyAttribute : Attribute
    {
        public ScriptDependencyAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public string Identifier { get; set; }
    }
}
