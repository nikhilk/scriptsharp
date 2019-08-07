using System.Runtime.CompilerServices;

namespace System.Collections.Generic
{
    [ScriptImport]
    [ScriptName("IDictionary")]
    public interface IDictionary<TKey, TValue>
        : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        [ScriptField]
        TValue this[TKey key]
        {
            get;
            set;
        }

        ICollection<TKey> Keys { get; }

        ICollection<TValue> Values { get; }

        [DSharpScriptMemberName("keyExists")]
        bool ContainsKey(TKey key);

        [DSharpScriptMemberName("addKeyValue")]
        void Add(TKey key, TValue value);

        bool Remove(TKey key);
    }
}
