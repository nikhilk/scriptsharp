using System.Runtime.CompilerServices;

namespace System.Collections.Generic
{
    public interface IReadOnlyList<T> : IReadOnlyCollection<T>
    {
        [ScriptField]
        T this[int index]
        {
            get;
        }
    }
}
