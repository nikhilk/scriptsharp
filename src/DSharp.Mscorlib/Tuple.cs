using System.Runtime.CompilerServices;

namespace System
{
    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Tuple")]
    public sealed class Tuple<T1, T2>
    {
        public Tuple() { }

        public Tuple(T1 item1, T2 item2) { }

        [ScriptField]
        public extern T1 Item1 { get; set; }

        [ScriptField]
        public extern T2 Item2 { get; set; }
    }

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Tuple")]
    public sealed class Tuple<T1, T2, T3>
    {
        public Tuple() { }

        public Tuple(T1 item1, T2 item2, T3 item3) { }

        [ScriptField]
        public extern T1 Item1 { get; set; }

        [ScriptField]
        public extern T2 Item2 { get; set; }

        [ScriptField]
        public extern T3 Item3 { get; set; }
    }

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Tuple")]
    public sealed class Tuple<T1, T2, T3, T4>
    {
        public Tuple() { }

        public Tuple(T1 item1, T2 item2, T3 item3, T4 item4) { }

        [ScriptField]
        public extern T1 Item1 { get; set; }

        [ScriptField]
        public extern T2 Item2 { get; set; }

        [ScriptField]
        public extern T3 Item3 { get; set; }

        [ScriptField]
        public extern T4 Item4 { get; set; }
    }
}
