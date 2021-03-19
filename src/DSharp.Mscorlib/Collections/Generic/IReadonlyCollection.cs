using System.Runtime.CompilerServices;

namespace System.Collections.Generic
{
    [ScriptIgnoreGenericArguments(UseGenericName = true)]
    public interface IReadOnlyCollection<T> : IEnumerable<T>
    {
        [ScriptField]
        [ScriptName("length")]
        int Count { get; }
    }
}
