using System.Runtime.CompilerServices;

namespace System.Globalization
{
    [ScriptImport]
    [ScriptName("culture")]
    public sealed class CultureInfo
    {
        private CultureInfo() { }

        [ScriptField]
        [ScriptName("current")]
        public extern static CultureInfo CurrentCulture { get; }

        [ScriptField]
        [ScriptName("dtf")]
        public extern DateFormatInfo DateFormat { get; }

        [ScriptField]
        [ScriptName("neutral")]
        public extern static CultureInfo InvariantCulture { get; }

        [ScriptField]
        public extern string Name { get; }

        [ScriptField]
        [ScriptName("nf")]
        public extern NumberFormatInfo NumberFormat { get; }
    }
}
