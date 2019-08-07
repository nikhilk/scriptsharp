namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Event, Inherited = true, AllowMultiple = false)]
    [ScriptIgnore]
    public sealed class ScriptEventAttribute : Attribute
    {
        public ScriptEventAttribute(string addAccessor, string removeAccessor)
        {
            AddAccessor = addAccessor;
            RemoveAccessor = removeAccessor;
        }

        public string AddAccessor { get; }

        public string RemoveAccessor { get; }
    }
}
