namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// This attribute allows specifying a script name for an imported method.
    /// The method is interpreted as a global method. As a result it this attribute
    /// only applies to static methods.
    /// </summary>
    // REVIEW: Eventually do we want to support this on properties/field and instance methods as well?
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    [ScriptIgnore]
    public sealed class ScriptAliasAttribute : Attribute
    {
        public ScriptAliasAttribute(string alias)
        {
            Alias = alias;
        }

        public string Alias { get; }
    }
}
