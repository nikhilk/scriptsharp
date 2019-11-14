using System.Runtime.CompilerServices;

namespace System.Collections
{
    public interface IList : ICollection
    {
        [ScriptField]
        object this[int index]
        {
            get;
            set;
        }

        [ScriptName("push")]
        int Add(object value);

        [DSharpScriptMemberName("contains")]
        bool Contains(object value);

        [DSharpScriptMemberName("clear")]
        void Clear();

        int IndexOf(object value);

        [DSharpScriptMemberName("insert")]
        void Insert(int index, object value);

        [DSharpScriptMemberName("removeItem")]
        void Remove(object value);

        [DSharpScriptMemberName("removeAt")]
        void RemoveAt(int index);
    }
}
