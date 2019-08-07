using System.Runtime.CompilerServices;

namespace System
{
    /// <summary>
    /// Marks an assembly as a script assembly that can be used with Script#.
    /// Additionally, each script must have a unique name that can be used as
    /// a dependency name.
    /// This name is also used to generate unique names for internal types defined
    /// within the assembly. The ScriptQualifier attribute can be used to provide a
    /// shorter name if needed.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = false)]
    [ScriptIgnore]
    [ScriptImport]
    public sealed class ScriptAssemblyAttribute : Attribute
    {
        public ScriptAssemblyAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public string Identifier { get; set; }
    }
}
