using System.Runtime.CompilerServices;
using DSharp;

namespace System
{

    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName(DSharpStringResources.ASSEMBLY_NAME)]
    public static class Activator
    {
        public extern static object CreateInstance(Type type);

        public extern static T CreateInstance<T>();

        public extern static object CreateInstance(Type type, params object[] args);
    }
}
