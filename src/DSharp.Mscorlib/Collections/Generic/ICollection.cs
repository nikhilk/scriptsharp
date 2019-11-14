using System.Runtime.CompilerServices;

namespace System.Collections.Generic
{
    public interface ICollection<T> : IEnumerable<T>, IEnumerable
    {
        [ScriptField]
        [ScriptName("length")]
        int Count { get; }

        [ScriptName("push")]
        void Add(T item);

        [DSharpScriptMemberName("clear")]
        void Clear();

        [DSharpScriptMemberName("contains")]
        bool Contains(T item);

        [DSharpScriptMemberName("removeItem")]
        bool Remove(T item);
    }
}
