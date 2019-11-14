using System.Runtime.CompilerServices;

namespace System.Collections
{
    public interface ICollection : IEnumerable
    {
        [ScriptField]
        [ScriptName("length")]
        int Count { get; }
    }
}
