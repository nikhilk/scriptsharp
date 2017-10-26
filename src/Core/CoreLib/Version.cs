using System.Runtime.CompilerServices;

namespace System
{
    [ScriptIgnore]
    public sealed class Version
    {
        [ScriptField]
        public extern int Major
        {
            get;
        }

        [ScriptField]
        public extern int Minor
        {
            get;
        }

        [ScriptField]
        public extern int Build
        {
            get;
        }

        [ScriptField]
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