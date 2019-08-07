using System.Runtime.CompilerServices;

namespace System.Runtime.Versioning
{
    [AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = false)]
    [ScriptIgnore]
    public sealed class TargetFrameworkAttribute : Attribute
    {
        public TargetFrameworkAttribute(string frameworkName)
        {
            FrameworkName = frameworkName;
        }

        public string FrameworkDisplayName { get; set; }

        public string FrameworkName { get; }
    }
}
