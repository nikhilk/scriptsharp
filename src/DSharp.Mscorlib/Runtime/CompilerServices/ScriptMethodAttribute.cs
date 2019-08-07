namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    [ScriptIgnore]
    public sealed class ScriptMethodAttribute : Attribute
    {
        public ScriptMethodAttribute(string selector)
        {
            Selector = selector;
        }

        public string Selector { get; }
    }
}
