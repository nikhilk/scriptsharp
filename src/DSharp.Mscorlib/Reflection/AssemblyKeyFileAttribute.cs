using System.Runtime.CompilerServices;

namespace System.Reflection
{
    [AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
    [ScriptIgnore]
    public sealed class AssemblyKeyFileAttribute : Attribute
    {
        public AssemblyKeyFileAttribute(string keyFile)
        {
            KeyFile = keyFile;
        }

        public string KeyFile { get; }
    }
}
