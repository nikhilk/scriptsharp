using System.Collections;
using System.Runtime.CompilerServices;

namespace System.Collections.Generic
{
    [ScriptImport]
    [ScriptName("IEnumerator")]
    public interface IEnumerator<T> : IEnumerator
    {
        [ScriptField]
        new T Current { get; }
    }
}
