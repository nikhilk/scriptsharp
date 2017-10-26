using System.Runtime.CompilerServices;

namespace System
{
    [ScriptImport]
    public sealed class Version
    {
        [ScriptField]
        [ScriptName(PreserveCase = true)]
        public extern int Major
        {
            get;
        }

        [ScriptField]
        [ScriptName(PreserveCase = true)]
        public extern int Minor
        {
            get;
        }

        [ScriptField]
        [ScriptName(PreserveCase = true)]
        public extern int Build
        {
            get;
        }

        [ScriptField]
        [ScriptName(PreserveCase = true)]
        public extern int Revision
        {
            get;
        }

        public Version(string version)
        {
        }

        [ScriptName(PreserveCase = true, PreserveName = true)]
        public extern static Version Parse(string version);
    }
}