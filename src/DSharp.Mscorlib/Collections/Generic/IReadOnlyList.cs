using System.Runtime.CompilerServices;

namespace System.Collections.Generic
{
    [ScriptImport]
    [ScriptName("IList")]
    public interface IReadOnlyList<T> : IReadOnlyCollection<T>
    {
        [ScriptField]
        T this[int index]
        {
            get;
        }
    }
}
