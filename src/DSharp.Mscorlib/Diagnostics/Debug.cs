using System.Runtime.CompilerServices;

namespace System.Diagnostics
{
    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("console")]
    public static class Debug
    {
        [Conditional("DEBUG")]
        public extern static void Assert(bool condition);

        [Conditional("DEBUG")]
        public extern static void Assert(bool condition, string message);

        [Conditional("DEBUG")]
        [DSharpScriptMemberName("fail")]
        public extern static void Fail(string message);

        [Conditional("DEBUG")]
        [ScriptName("log")]
        public extern static void WriteLine(string message);
    }
}
