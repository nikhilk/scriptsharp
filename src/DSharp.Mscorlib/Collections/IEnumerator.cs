using System.Runtime.CompilerServices;

namespace System.Collections
{
    [ScriptImport]
    public interface IEnumerator {

        [ScriptField]
        object Current { get; }

        bool MoveNext();

        void Reset();
    }
}
