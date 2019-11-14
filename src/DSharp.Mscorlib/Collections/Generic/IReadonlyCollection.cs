using System.Runtime.CompilerServices;

namespace System.Collections.Generic
{
    public interface IReadOnlyCollection<T> : IEnumerable<T>
    {
        [ScriptField]
        [ScriptName("length")]
        int Count { get; }
    }
}
