using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace System.CodeDom.Compiler
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    [ScriptIgnore]
    public sealed class GeneratedCodeAttribute : Attribute
    {
        public GeneratedCodeAttribute(string tool, string version)
        {
            Tool = tool;
            Version = version;
        }

        public string Tool { get; }

        public string Version { get; }
    }
}
