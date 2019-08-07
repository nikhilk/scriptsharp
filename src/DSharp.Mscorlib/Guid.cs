using System.Runtime.CompilerServices;

namespace System
{
    [ScriptImport]
    [ScriptName("Guid")]
    public struct Guid
    {
        [ScriptName(PreserveCase = true)]
        public extern static Guid NewGuid();

        [ScriptSkip]
        public extern override string ToString();
    }
}
