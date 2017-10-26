using System.Runtime.CompilerServices;

namespace System.Reflection
{
    [ScriptIgnore]
    public sealed class AssemblyName
    {
        [ScriptField]
        public extern string Name
        {
            get;
            set;
        }

        [ScriptField]
        public extern Version Version
        {
            get;
            set;
        }

        public AssemblyName(string assemblyName = null, Version version = null)
        {
        }
    }
}