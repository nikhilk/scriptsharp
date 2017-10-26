using System;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace BasicTests
{
    public class App
    {
        public App()
        {
            Type objectType = typeof(Object);
            string fullname = objectType.FullName;
            string nameSpace = objectType.Namespace;

            Assembly assembly = objectType.Assembly;
            string assemblyFullName = assembly.FullName;
            Type[] exportedTypes = assembly.ExportedTypes;

            AssemblyName assemblyName = assembly.GetName();
            string assemblyNameName = assemblyName.Name;
            Version assemblyVersion = assemblyName.Version;

            int major = assemblyVersion.Major;
            int minor = assemblyVersion.Minor;
            int build = assemblyVersion.Build;
            int revision = assemblyVersion.Revision;
        }
    }
}
