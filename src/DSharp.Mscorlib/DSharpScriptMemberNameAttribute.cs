namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// Marks a method or property as a core member of the DSharp script.
    /// The name should match the outputs of the public API for the DSharp script
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    [ScriptIgnore]
    internal class DSharpScriptMemberNameAttribute : Attribute
    {
        private readonly string memberName;

        internal DSharpScriptMemberNameAttribute(string memberName)
        {
            this.memberName = memberName;
        }

        public string MemberName
        {
            get { return memberName; }
        }
    }
}
