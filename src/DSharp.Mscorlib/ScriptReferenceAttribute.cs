using System.Runtime.CompilerServices;

namespace System
{
    [AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = true)]
    [ScriptIgnore]
    [ScriptImport]
    public sealed class ScriptReferenceAttribute : Attribute
    {
        public ScriptReferenceAttribute(string name)
        {
            Name = name;
        }

        public bool DelayLoad { get; set; }

        public string Identifier { get; set; }

        public string Name { get; }

        public string Path { get; set; }

        public bool IsExplicit { get; set; }
    }
}
