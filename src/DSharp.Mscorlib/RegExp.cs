using System.Runtime.CompilerServices;

namespace System
{
    //TODO: Look at moving to Javascript library
    /// <summary>
    /// Equivalent to the RegExp type in Javascript.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("RegExp")]
    public sealed class RegExp
    {
        public RegExp(string pattern) { }

        public RegExp(string pattern, string flags) { }

        [ScriptField]
        public extern int LastIndex { get; set; }

        [ScriptField]
        public extern bool Global { get; }

        [ScriptField]
        public extern bool IgnoreCase { get; }

        [ScriptField]
        public extern bool Multiline { get; }

        [ScriptField]
        public extern string Pattern { get; }

        [ScriptField]
        public extern string Source { get; }

        public extern string[] Exec(string s);

        [DSharpScriptMemberName("regexp")]
        public extern static RegExp Parse(string s);

        public extern bool Test(string s);
    }
}
