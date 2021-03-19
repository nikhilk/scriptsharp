using System.Runtime.CompilerServices;

namespace System.Collections.Generic
{
    [ScriptIgnoreGenericArguments(UseGenericName = true)]
    public interface IReadOnlyList<T> : IReadOnlyCollection<T>
    {
        [ScriptField]
        T this[int index]
        {
            get;
        }
    }
}
