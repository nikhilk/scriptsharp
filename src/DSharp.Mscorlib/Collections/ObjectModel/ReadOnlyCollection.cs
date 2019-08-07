using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Collections.ObjectModel
{
    //
    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("Array")]
    public class ReadOnlyCollection<T> : IReadOnlyList<T>
    {
        [ScriptField]
        [ScriptName("length")]
        public extern int Count { get; }

        [ScriptField]
        extern T IReadOnlyList<T>.this[int index] { get; }

        public extern IEnumerator GetEnumerator();

        extern IEnumerator<T> IEnumerable<T>.GetEnumerator();
    }
}
