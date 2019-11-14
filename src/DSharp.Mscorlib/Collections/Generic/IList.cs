using System.Runtime.CompilerServices;

namespace System.Collections.Generic
{
    public interface IList<T> : ICollection<T>
    {
        [ScriptField]
        T this[int index]
        {
            get;
            set;
        }

        int IndexOf(T item);

        [DSharpScriptMemberName("insert")]
        void Insert(int index, T item);

        [DSharpScriptMemberName("removeAt")]
        void RemoveAt(int index);
    }
}
