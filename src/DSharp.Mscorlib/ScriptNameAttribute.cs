using System.Runtime.CompilerServices;

namespace System
{
    /// <summary>
    /// Allows specifying the name to use for a type or member in the generated script.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method | AttributeTargets.Event, Inherited = false, AllowMultiple = false)]
    [ScriptIgnore]
    public sealed class ScriptNameAttribute : Attribute
    {
        public ScriptNameAttribute()
        {
        }

        public ScriptNameAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public bool PreserveCase { get; set; }

        public bool PreserveName { get; set; }
    }
}
