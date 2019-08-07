using System.Runtime.CompilerServices;

namespace System.Collections
{
    [ScriptImport]
    [ScriptName("ICollection")]
    public interface ICollection : IEnumerable
    {
        [ScriptField]
        [ScriptName("length")]
        int Count { get; }
    }
}
