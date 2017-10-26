using System.Runtime.CompilerServices;

namespace System.Reflection
{
    [ScriptImport]
    public sealed class Assembly
    {
        public extern string FullName
        {
            get;
        }

        public extern Type[] ExportedTypes
        {
            get;
        }

        internal Assembly(AssemblyName assemblyName, Type[] exportedTypes) { }
    }
}