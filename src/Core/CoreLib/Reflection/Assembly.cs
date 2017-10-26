using System.Runtime.CompilerServices;

namespace System.Reflection
{
    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class Assembly
    {
        [ScriptField]
        [ScriptName(PreserveCase = true)]
        public extern string FullName
        {
            get;
        }

        [ScriptField]
        [ScriptName(PreserveCase = true)]
        public extern Type[] ExportedTypes
        {
            get;
        }

        internal Assembly(AssemblyName assemblyName, Type[] exportedTypes) { }

        public extern AssemblyName GetName();
    }
}