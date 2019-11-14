using System.Runtime.CompilerServices;

namespace System.Collections
{
    public interface IEnumerator
    {

        [ScriptField]
        object Current { get; }

        bool MoveNext();

        void Reset();
    }
}
