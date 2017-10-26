using System.Runtime.CompilerServices;

namespace System.Reflection
{
    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class AssemblyName
    {
        [ScriptField]
        [ScriptName(PreserveCase = true)]
        public extern string Name
        {
            get;
            set;
        }

        [ScriptField]
        [ScriptName(PreserveCase = true)]
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