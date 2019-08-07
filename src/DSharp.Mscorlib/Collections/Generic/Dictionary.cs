using System.Runtime.CompilerServices;

namespace System.Collections.Generic
{
    /// <summary>
    /// The Dictionary data type which is mapped to the Object type in Javascript.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("Object")]
    public sealed partial class Dictionary<TKey, TValue>
        : IDictionary<TKey, TValue>
        , IDictionary
        , IReadOnlyDictionary<TKey, TValue>
    {
        public Dictionary() { }

        public extern IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator();

        extern IEnumerator IEnumerable.GetEnumerator();

        public extern ICollection<TKey> Keys { get; }

        extern ICollection IDictionary.Keys { get; }

        extern IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys { get; }

        public extern ICollection<TValue> Values { get; }

        extern ICollection IDictionary.Values { get; }

        extern IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values { get; }

        [ScriptField]
        public extern TValue this[TKey key] { get; set; }

        [ScriptField]
        extern object IDictionary.this[object key] { get; set; }

        [DSharpScriptMemberName("addKeyValue")]
        public extern void Add(TKey key, TValue value);

        [DSharpScriptMemberName("addKeyValue")]
        public extern void Add(object key, object value);

        [Obsolete("This is only for use by the c# compiler, and cannot be used for generating script.", error: true)]
        public extern void Add(KeyValuePair<TKey, TValue> item);

        [DSharpScriptMemberName("clearKeys")]
        public extern void Clear();

        [DSharpScriptMemberName("keyExists")]
        public extern bool ContainsKey(TKey key);

        [DSharpScriptMemberName("keyExists")]
        public extern bool Contains(object key);

        [Obsolete("This is only for use by the c# compiler, and cannot be used for generating script.", error: true)]
        public extern bool Contains(KeyValuePair<TKey, TValue> item);

        public extern bool Remove(TKey key);

        public extern void Remove(object key);

        [Obsolete("This is only for use by the c# compiler, and cannot be used for generating script.", error: true)]
        public extern bool Remove(KeyValuePair<TKey, TValue> item);
    }
}
